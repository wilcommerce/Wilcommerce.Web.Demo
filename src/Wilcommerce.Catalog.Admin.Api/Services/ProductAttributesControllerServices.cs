using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Wilcommerce.Catalog.Admin.Models.ProductAttributes;
using Wilcommerce.Catalog.ReadModels;

namespace Wilcommerce.Catalog.Admin.Api.Services
{
    public class ProductAttributesControllerServices : IProductAttributesControllerServices
    {
        public ICatalogDatabase Database { get; }

        public ProductAttributesControllerServices(ICatalogDatabase database)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public IEnumerable<ProductAttributeListModel> GetProductAttributes(Guid productId)
        {
            var attributesQuery = Database.ProductAttributes
                .Include(a => a.Product)
                .Include(a => a.Attribute)
                .ByProduct(productId);

            var attributes = attributesQuery
                .OrderBy(a => a.Attribute.Name)
                .Select(a => new ProductAttributeListModel
                {
                    Id = a.Id,
                    AttributeId = a.Attribute.Id,
                    AttributeName = a.Attribute.Name,
                    Value = a.Value
                }).ToArray();

            return attributes;
        }
    }
}
