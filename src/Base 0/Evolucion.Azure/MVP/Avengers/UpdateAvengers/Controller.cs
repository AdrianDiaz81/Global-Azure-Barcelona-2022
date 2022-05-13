namespace MVP.Avengers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using MVP.Avengers.UpdateAvengers.Command;

    public class UpdateAvengersController:Controllers.Controller
    {
        private readonly ILogger<GetAllAvengersController> _logger;

        public UpdateAvengersController(IMediator mediator, ILogger<GetAllAvengersController> logger) : base(mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPut("api/avengers")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]                
        public async Task<IActionResult> UpdateAvengers(Request command)
        {                        
            return await RequestAsync(command);
        }
    }
}
