namespace MyProject.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public NotFoundException(string message = "The requested resource was not found") : base(message, 404, "NOT_FOUND")
        {
            // Do Nothing...
        }
    }
}
