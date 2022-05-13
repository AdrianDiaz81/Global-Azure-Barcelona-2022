namespace MVP.Avengers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using MVP.Avengers.GetAvengers;
    using MVP.Avengers.InsertAvengers;
    using MVP.Avengers.InsertAvengers.Command;

    public class InsertAvengersController:Controllers.Controller
    {
        private readonly ILogger<GetAllAvengersController> _logger;

        public InsertAvengersController(IMediator mediator, ILogger<GetAllAvengersController> logger) : base(mediator)
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        [HttpPost("api/avengers")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]                
        public async Task<IActionResult> InsertAvengers(Request command)
        {                        
            return await RequestAsync(command);
        }
    }
}
