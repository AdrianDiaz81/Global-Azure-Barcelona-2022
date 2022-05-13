using MediatR;
using MVP.Model;

namespace MVP.Avengers.GetAvengers
{
    public class Query : AvengersListDto, IRequest<Response<AvengersListDto>>
    {
    }
}
