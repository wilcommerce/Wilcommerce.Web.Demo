using System.Collections.Generic;

namespace Wilcommerce.Core.Admin.Models
{
    public abstract class ListModel<TListItem> where TListItem : class
    {
        public int Total { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<TListItem> Items { get; set; }
    }
}
