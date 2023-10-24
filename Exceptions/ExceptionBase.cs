using System.Net;
using System.Text.Json;

namespace MyProject.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public readonly int StatusCode;
        public readonly string Code;

        public ExceptionBase(string message, int statusCode, string code) : base(message)
        {
            StatusCode = statusCode;
            Code = code;
        }

        public static void ThrowFromHttpResponseMessage(HttpResponseMessage responseMessage)
        {
            string message = JsonDocument.Parse(responseMessage.Content.ReadAsStringAsync().Result).RootElement.GetProperty("error").GetProperty("message").GetString()!;

            if (responseMessage.StatusCode == HttpStatusCode.Conflict)
            {
                throw new ConflictException(message);
            }

            if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new NotFoundException(message);
            }

            throw new GenericException();
        }
    }
}
