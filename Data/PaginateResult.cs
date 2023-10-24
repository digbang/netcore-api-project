namespace MyProject.Data
{
    public class PaginateResult
    {
        public readonly int Count;
        public readonly int TotalPages;
        public readonly int PerPage = 10;
        public readonly int CurrentPage = 1;
        public readonly IDictionary<string, string> Links = new Dictionary<string, string>();

        public PaginateResult(PageData pagination, int count)
        {
            Count = count;
            TotalPages = (int) Math.Ceiling((double) count / pagination.Limit);
            PerPage = pagination.Limit;
            CurrentPage = pagination.Page;
        }

        public void AddLink(string name, string link)
        {
            Links[name] = link;
        }
    }
}
