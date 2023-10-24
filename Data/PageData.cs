using System.ComponentModel.DataAnnotations;

namespace MyProject.Data
{
    public class PageData
    {
        [Range(1, int.MaxValue)]
        public required int Limit { get; set; } = 10;

        [Range(1, int.MaxValue)]
        public required int Page { get; set; } = 1;
    }
}
