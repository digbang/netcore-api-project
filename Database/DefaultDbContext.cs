using Microsoft.EntityFrameworkCore;

namespace MyProject.Database
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
            // Do Nothing...
        }
    }
}
