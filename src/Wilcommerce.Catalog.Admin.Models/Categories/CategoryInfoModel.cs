using System;
using System.ComponentModel.DataAnnotations;

namespace Wilcommerce.Catalog.Admin.Models.Categories
{
    public class CategoryInfoModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public string Description { get; set; }

        public bool IsVisible { get; set; }

        public DateTime? VisibleFrom { get; set; }

        public DateTime? VisibleTo { get; set; }
    }
}
