using FluentValidation;
using MVP.Model;

namespace MVP.Avengers.GetAvengers
{
    public class Validator : Validator<Query>
    {
    }

    public class Validator<T> : AbstractValidator<T> where T : AvengersListDto
    {
        public Validator()
        {
            
        }
    }
}
