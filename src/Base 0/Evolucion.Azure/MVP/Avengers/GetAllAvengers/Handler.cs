using MediatR;
using MVP.Model;
using MVP.Services;

namespace MVP.Avengers.GetAvengers
{
    public class Handler : IRequestHandler<Query, Response<AvengersListDto>>
    {
        private readonly IAvengersService _service;
        private readonly ILogger<Handler> _logger;
        public Handler(IAvengersService avengersService, ILogger<Handler> logger )
        {
            _service= avengersService;
            _logger= logger;
        }
        public async Task<Response<AvengersListDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Get avengers available");
            var avengers = await _service.GetAllAsync();
            return new Response<AvengersListDto>(avengers);            
        }
    }
}
