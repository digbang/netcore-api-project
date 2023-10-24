namespace MyProject.Exceptions
{
    public class ConflictException : ExceptionBase
    {
        public ConflictException(string message = "The record you are trying to create already exists in our records") : base(message, 409, "CONFLICT")
        {
            // Do Nothing...
        }
    }
}
