using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Wilcommerce.Catalog.Admin.Models.Brands
{
    public class BrandInfoModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }
    }
}
