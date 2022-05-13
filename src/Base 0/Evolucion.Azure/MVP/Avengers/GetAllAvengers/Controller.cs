namespace MVP.Avengers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using MVP.Avengers.GetAvengers;

    [Route("api/avengers")]
    [ApiController]
    public class GetAllAvengersController:Controllers.Controller
    {
        private readonly ILogger<GetAllAvengersController> _logger;

        public GetAllAvengersController(IMediator mediator, ILogger<GetAllAvengersController> logger) : base(mediator)
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]                
        public async Task<IActionResult> GetAllAvengers()
        {                        
            return await RequestAsync(new Query());
        }
    }
}
