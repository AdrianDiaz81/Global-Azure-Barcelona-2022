using MediatR;
using MVP.Avengers.DeleteAvengers.Command;
using MVP.Services;

namespace MVP.Avengers.DeleteAvengers
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IAvengersService _service;
        private readonly ILogger<Handler> _logger;
        public Handler(IAvengersService avengersService, ILogger<Handler> logger)
        {
            _service = avengersService;
            _logger = logger;
        }
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Update avengers available");
            var avengers = await _service.DeleteAsync(request.Id.ToString());
            return new Response(avengers);
        }
    }
}
