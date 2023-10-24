namespace MyProject.Utils
{
    public static class UrlGenerator
    {
        public static string BaseUrl(HttpRequest request, bool includePath = true)
        {
            string baseUrl = $"{request.Scheme}://{request.Host}";

            if (includePath)
            {
                return $"{baseUrl}{request.Path}";
            }

            return baseUrl;
        }
    }
}
