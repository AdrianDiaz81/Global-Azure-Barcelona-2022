using FluentValidation;
using MVP.Model;

namespace MVP.Avengers.GetAvengersById
{
    public class Validator : Validator<Query>
    {

    }

    public class Validator<T> : AbstractValidator<T> where T : AvengersDto
    {
        public Validator()
        {
            RuleFor((T x) => x.Id).NotEmpty();
        }
    }
}
