namespace MVP.Avengers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using MVP.Avengers.GetAvengers;
    using Newtonsoft.Json;

    [Route("api/avengers/id")]
    [ApiController]
    public class GetAvengersByIdController:Controllers.Controller
    {
        private readonly ILogger<GetAvengersByIdController> _logger;

        public GetAvengersByIdController(IMediator mediator, ILogger<GetAvengersByIdController> logger) : base(mediator)
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]                
        public async Task<IActionResult> GetAvengersById(string userId)
        {
            var query = new GetAvengersById.Query
            {
                Id = Convert.ToInt32(userId)
            };
            _logger.LogInformation($"GetAvengersById --> Query: {JsonConvert.SerializeObject(query)}");
            return await RequestAsync(query);
        }
    }
}
