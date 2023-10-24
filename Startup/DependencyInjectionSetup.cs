using MyProject.Contracts.Utils;
using MyProject.Utils;

namespace MyProject.Startup;

public static class DependencyInjectionSetup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        #region Services
        #endregion

        #region Repositories
        #endregion

        #region Utils
        services.AddScoped<IPagination, Pagination>();
        #endregion
    }
}
