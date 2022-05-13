using MediatR;

namespace MVP.Avengers.DeleteAvengers.Command
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
        

        public Response Convert()
        {
            return new Response(true);
        }

    }
}
