using MediatR;
using MVP.Model;

namespace MVP.Avengers.GetAvengersById
{
    public class Query : AvengersDto, IRequest<Response<AvengersDto>>
    {
    }
}
