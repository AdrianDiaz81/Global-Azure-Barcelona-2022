using MediatR;
using MVP.Avengers.InsertAvengers.Command;
using MVP.Model;
using MVP.Services;

namespace MVP.Avengers.InsertAvengers
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IAvengersService _service;
        private readonly ILogger<Handler> _logger;
        public Handler(IAvengersService avengersService, ILogger<Handler> logger )
        {
            _service= avengersService;
            _logger= logger;
        }
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Insert avengers available");
            var avengers = await _service.InsertAsync(new AvengersDto
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                UrlPhoto = request.UrlPhoto
            });
            return new Response(avengers);            
        }
    }
}
