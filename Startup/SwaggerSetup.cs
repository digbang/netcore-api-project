using Microsoft.OpenApi.Models;
using MyProject.SchemaFilters;

namespace MyProject.Startup;

public static class SwaggerSetup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var apiName = configuration.GetValue<string>("SWAGGER_API_NAME");
        var apiVersion = configuration.GetValue<string>("SWAGGER_API_VERSION");

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(apiVersion, new OpenApiInfo
            {
                Title = apiName, Version = apiVersion
            });

            options.SchemaFilter<EnumSchemaFilter>();
        });
    }
}
