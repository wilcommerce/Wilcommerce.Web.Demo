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

        public CategoryDescriptor Parent { get; set; }

        public IList<CategoryDescriptor> Children { get; set; }

        public CategoryDetailModel()
        {
            Children = new List<CategoryDescriptor>();
        }

        public class CategoryDescriptor
        {
            public Guid Id { get; set; }

            public string Code { get; set; }

            public string Name { get; set; }
        }
    }
}
