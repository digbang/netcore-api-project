using Microsoft.EntityFrameworkCore;
using MyProject.Database;

namespace MyProject.Startup;

public static class DatabaseSetup
{
    private const string Sqlite = "sqlite";
    private const string SqlServer = "sqlserver";

    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        if (SqlServer == configuration.GetValue("DB_CONNECTION", Sqlite))
        {
            services.AddDbContext<DefaultDbContext>(options =>
                options.UseSqlServer(configuration.GetValue<string>("DB_CONNECTION_STRING")));
        }
        else
        {
            services.AddDbContext<DefaultDbContext>(options =>
                options.UseSqlite(configuration.GetValue<string>("DB_CONNECTION_STRING")));
        }
    }
}
