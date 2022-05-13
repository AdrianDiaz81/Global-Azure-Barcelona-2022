using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System.Net;


namespace MVP.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging.Abstractions;
    using System.Net;
    public abstract class Controller : MediatorControllerBase
    {
        public Controller(IMediator mediator) : base(mediator) { }

        protected override async Task<IActionResult> HandleResponseAsync<TResponse>(TResponse response)
        {
            return response switch
            {
                AcceptedResponse => Accepted(),
                _ => await base.HandleResponseAsync(response).ConfigureAwait(false)
            };
        }

        protected override Task<IActionResult> HandleExceptionAsync(Exception ex)
        {
            return Task.FromResult<IActionResult>(ex switch
            {
                EntityNotFoundValidationException x => NotFound(x.Errors),
                RequestValidationException x => BadRequest(x.Errors),
                _ => StatusCode(500, ex.Message)
            });
        }
    }

    public class AcceptedResponse
    {
    }
    public class EntityNotFoundValidationException : RequestValidationException
    {
    }

    public abstract class MediatorControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public MediatorControllerBase(IMediator mediator) : this(mediator, NullLogger.Instance)
        {
        }

        public MediatorControllerBase(IMediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        protected ILogger Logger => _logger;

        protected virtual async Task<IActionResult> RequestAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
            where TResponse : class
        {
            if (request == null) return BadRequest();

            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return await HandleResponseAsync(response);

            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }
        }

        protected virtual Task<IActionResult> RequestAsync<TResponse>(IRequest<TResponse> request, Func<TResponse, IActionResult> action, CancellationToken cancellationToken = default)
        {
            Func<TResponse, Task<IActionResult>> actionAsync = response => Task.FromResult(action(response));
            return RequestAsync(request, actionAsync, cancellationToken);
        }

        protected virtual async Task<IActionResult> RequestAsync<TResponse>(IRequest<TResponse> request, Func<TResponse, Task<IActionResult>> action, CancellationToken cancellationToken = default)
        {
            action = action ?? throw new ArgumentNullException(nameof(action));
            if (request == null) return BadRequest();

            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return await action(response);
            }
            catch (Exception ex)
            {
                var result = await HandleExceptionWithActionAsync(request, ex);
                if (result != default(IActionResult))
                {
                    return result;
                }

                throw;
            }
        }

        protected virtual Task<IActionResult> HandleExceptionAsync(Exception ex)
        {
            ex = ex ?? throw new ArgumentNullException(nameof(ex));
            _logger.LogError(ex,ex.Message);

            return Task.FromResult<IActionResult>(ex switch
            {
                RequestValidationException rex => BadRequest(rex.Errors),
                BusinessValidationException bex => Conflict(bex.Message),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)
            });
        }

        protected virtual Task<IActionResult> HandleExceptionWithActionAsync<TResponse>(IRequest<TResponse> request, Exception ex)
        {
            return HandleExceptionAsync(ex);
        }

        protected virtual Task<IActionResult> HandleResponseAsync<TResponse>(TResponse response)
            where TResponse : class
        {
            return Task.FromResult<IActionResult>(response switch
            {
                null => NotFound(),
                ICommandResult r when r.IsSuccess => Ok(r.PayloadObject),
                ICommandResult r when !r.IsSuccess => Conflict(r.ErrorMessage),
                _ => Ok(response)

            });
        }
    }
}

