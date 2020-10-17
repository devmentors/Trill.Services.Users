using System.Collections.Generic;
using System.Linq;

namespace Trill.Services.Users.Core.DTO
{
    public class PagedDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public bool Empty => Items is null || !Items.Any();
        public int CurrentPage { get; set; }
        public int ResultsPerPage { get; set; }
        public int TotalPages { get; set; }
        public long TotalResults { get; set; }
    }
}