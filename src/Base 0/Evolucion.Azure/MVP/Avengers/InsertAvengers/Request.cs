using MediatR;
using MVP.Model;

namespace MVP.Avengers.InsertAvengers.Command
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlPhoto { get; set; }
        public string Description { get; set; }

        public Response Convert()
        {
            return new Response(true);
        }

    }
}
