using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyProject.Database;
using MyProject.Exceptions;

namespace MyProject.Repositories
{
    public abstract class DatabaseRepository
    {
        protected readonly DefaultDbContext _context;

        public DatabaseRepository(DefaultDbContext context)
        {
            _context = context;
        }

        public T Save<T>(T entity) where T : class
        {
            DbSet<T> dbSet = _context.Set<T>();
            EntityEntry entry = dbSet.Entry(entity);

            switch (entry.State)
            {
                case EntityState.Added:
                case EntityState.Detached:
                    dbSet.Add(entity);
                    break;
                case EntityState.Modified:
                    dbSet.Update(entity);
                    break;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException sqlEx && (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                    throw new ConflictException($"Unable to create record due to duplicate fields");
                }

                throw e;
            }

            return entity;
        }
    }
}
