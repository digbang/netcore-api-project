namespace MyProject.Exceptions
{
    public class UnauthorizedException : ExceptionBase
    {
        public UnauthorizedException(string message = "Unauthorized") : base(message, 401, "UNAUTHORIZED")
        {
            // Do Nothing...
        }
    }
}
