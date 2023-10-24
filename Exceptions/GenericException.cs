namespace MyProject.Exceptions
{
    public class GenericException : ExceptionBase
    {
        public readonly Exception? Original;

        public GenericException(string message = "Internal Server Error", Exception? original = null) : base(message, 500, "INTERNAL_SERVER_ERROR")
        {
            Original = original;
        }
    }
}
