using FluentValidation;
using MVP.Avengers.DeleteAvengers.Command;

namespace MVP.Avengers.DeleteAvengers
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Id).NotEmpty();                        
        }
    }    
}
