using MyProject.Contracts.Utils;
using MyProject.Data;

namespace MyProject.Utils
{
    public class Pagination : IPagination
    {
        private readonly HttpRequest _request;

        public Pagination(IHttpContextAccessor httpContextAccessor)
        {
            _request = httpContextAccessor?.HttpContext?.Request!;
        }

        public (ICollection<T>, PaginateResult) Paginate<T>(IQueryable<T> query, Data.PageData pagination)
        {
            int count = query.Count();

            ICollection<T> items = query
                .Skip((pagination.Page - 1) * pagination.Limit)
                .Take(pagination.Limit)
                .ToList();

            PaginateResult result = BuildPageLinks(new (pagination, count));

            return (items, result);
        }

        private PaginateResult BuildPageLinks(PaginateResult result)
        {
            string baseUrl = UrlGenerator.BaseUrl(_request);

            if (result.CurrentPage >= 1 && result.CurrentPage < result.TotalPages)
            {
                result.AddLink("next", $"{baseUrl}?page={result.CurrentPage + 1}&limit={result.PerPage}");
            }

            if (result.CurrentPage > 1 && result.CurrentPage <= result.TotalPages)
            {
                result.AddLink("prev", $"{baseUrl}?page={result.CurrentPage - 1}&limit={result.PerPage}");
            }

            return result;
        }
    }
}
