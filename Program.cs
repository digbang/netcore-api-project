using MyProject.Middlewares;

dotenv.net.DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

MyProject.Startup.DatabaseSetup.ConfigureServices(builder.Services, builder.Configuration);
MyProject.Startup.DependencyInjectionSetup.ConfigureServices(builder.Services, builder.Configuration);
MyProject.Startup.SwaggerSetup.ConfigureServices(builder.Services, builder.Configuration);
MyProject.Startup.CorsSetup.ConfigureServices(builder.Services);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", app.Configuration.GetValue<string>("SWAGGER_API_NAME"));
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
