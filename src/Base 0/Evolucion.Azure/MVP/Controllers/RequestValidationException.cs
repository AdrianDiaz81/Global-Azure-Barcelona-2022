namespace MVP.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RequestValidationException : Exception
    {
        public RequestValidationException()
        {
        }

        public RequestValidationException(string message) : base(message)
        {
        }

        public RequestValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RequestValidationException(params ValidationError[] errors) : this(errors.AsEnumerable())
        {
        }

        public RequestValidationException(IEnumerable<ValidationError> errors)
            : base(errors != null ? string.Join("|", errors.Select((x, i) => $" Error Num.{i} ErrorMessage: {x.ErrorMessage}, AttemptedValue: {x.AttemptedValue}, PropertyName: {x.PropertyName}")) : string.Empty)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationError> Errors { get; private set; } = new List<ValidationError>();
    }
}
