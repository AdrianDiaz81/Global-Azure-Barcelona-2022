namespace MVP.Avengers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using MVP.Avengers.DeleteAvengers.Command;

    public class DeleteController:Controllers.Controller
    {
        private readonly ILogger<GetAllAvengersController> _logger;

        public DeleteController(IMediator mediator, ILogger<GetAllAvengersController> logger) : base(mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpDelete("api/avengers")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]                
        public async Task<IActionResult> DeleteAvengers(Request command)
        {                        
            return await RequestAsync(command);
        }
    }
}
