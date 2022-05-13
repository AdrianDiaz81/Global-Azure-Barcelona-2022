namespace MVP.Controllers
{
    public interface ICommandResult
    {
        object PayloadObject { get; }

        string ErrorMessage { get; }

        bool IsSuccess { get; }
    }
}
