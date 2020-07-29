using System;
using System.Collections.Generic;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Models.Categories
{
    public class CategoryDetailModel
    {
        public Guid Id { get; set; }

        public CategoryInfoModel Details { get; set; }

        public SeoData Seo { get; set; }

        public CategoryDescriptorModel Parent { get; set; }

        public IList<CategoryDescriptorModel> Children { get; set; }

        public CategoryDetailModel()
        {
            Children = new List<CategoryDescriptorModel>();
        }
    }
}
