namespace MVP.Controllers
{
    public class BusinessValidationException : Exception
    {
        public BusinessValidationException()
        {
        }

        public BusinessValidationException(string message) : base(message)
        {
        }

        public BusinessValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BusinessValidationException(string name, string description) : this($"{name}: {description}")
        {
        }

        public BusinessValidationException(string name, string description, Exception innerException) : this($"{name}: {description}", innerException)
        {
        }
    }
}
