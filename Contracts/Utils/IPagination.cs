using MyProject.Data;

namespace MyProject.Contracts.Utils
{
    public interface IPagination
    {
        (ICollection<T>, PaginateResult) Paginate<T>(IQueryable<T> query, PageData pagination);
    }
}
