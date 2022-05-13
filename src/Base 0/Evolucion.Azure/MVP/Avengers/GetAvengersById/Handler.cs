using MediatR;
using MVP.Model;
using MVP.Services;

namespace MVP.Avengers.GetAvengersById
{
    public class Handler : IRequestHandler<Query, Response<AvengersDto>>
    {
        private readonly IAvengersService _service;
        private readonly ILogger<Handler> _logger;
        public Handler(IAvengersService avengersService, ILogger<Handler> logger )
        {
            _service= avengersService;
            _logger= logger;
        }
        public async Task<Response<AvengersDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Get avengers available");
            var avengers = await _service.GetByIdAsync(request.Id.ToString());
            return new Response<AvengersDto>(avengers);            
        }
    }
}
