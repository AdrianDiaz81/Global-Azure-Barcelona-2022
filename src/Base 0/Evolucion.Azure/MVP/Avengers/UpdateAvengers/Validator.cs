using FluentValidation;
using MVP.Avengers.UpdateAvengers.Command;

namespace MVP.Avengers.UpdateAvengers
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x=>x.UrlPhoto).NotEmpty();
            RuleFor(x=>x.Name).NotEmpty();                    
        }
    }    
}
