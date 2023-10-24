using MyProject.Data;

namespace MyProject.Views
{
    public static class PaginationView
    {
        public static object MakeOne(PaginateResult result)
        {
            return new
            {
                result.Count,
                result.TotalPages,
                result.PerPage,
                result.CurrentPage,
                result.Links,
            };
        }
    }
}
