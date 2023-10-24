using System.Text.Json;
using MyProject.Exceptions;

namespace MyProject.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly IConfiguration _configuration;
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(IConfiguration configuration, RequestDelegate next)
        {
            _configuration = configuration;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ExceptionBase e)
            {
                WriteErrorResponse(context, e);
            }
            catch (Exception e)
            {
                WriteErrorResponse(context, new GenericException(original: e));
            }
        }

        private void WriteErrorResponse(HttpContext context, ExceptionBase e)
        {
            bool isDevelopment = _configuration.GetValue<bool>("DEBUG", false);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = e.StatusCode;

            dynamic error = new System.Dynamic.ExpandoObject();
            error.code = e.Code;
            error.message = e.Message;

            if (isDevelopment && e is GenericException genericException && genericException.Original != null)
            {
                error.message = genericException.Original.Message;
                error.stack = genericException.Original.StackTrace;

                Exception? innerException = genericException.Original.InnerException;

                if (innerException != null)
                {
                    error.innerException = new
                    {
                        message = innerException.Message,
                        stack = innerException.StackTrace
                    };
                }
            }

            context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                statusCode = e.StatusCode,
                success = false,
                error,
            }));
        }
    }
}
