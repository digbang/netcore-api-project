namespace MyProject.Exceptions
{
    public class JWTTokenNotProvidedException : UnauthorizedException
    {
        public JWTTokenNotProvidedException(string message = "JWT Token not provided") : base(message)
        {
            // Do Nothing...
        }
    }
}
