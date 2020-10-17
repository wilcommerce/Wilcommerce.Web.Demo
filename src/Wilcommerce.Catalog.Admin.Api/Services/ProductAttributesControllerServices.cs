using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.ProductAttributes;
using Wilcommerce.Catalog.Commands;
using Wilcommerce.Catalog.ReadModels;

namespace Wilcommerce.Catalog.Admin.Api.Services
{
    public class ProductAttributesControllerServices : IProductAttributesControllerServices
    {
        public ICatalogDatabase Database { get; }

        public IProductCommands Commands { get; }

        public ProductAttributesControllerServices(ICatalogDatabase database, IProductCommands commands)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
            Commands = commands ?? throw new ArgumentNullException(nameof(commands));
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

        public ProductAttributeModel GetProductAttributeDetail(Guid productId, Guid attributeId)
        {
            var attribute = Database.ProductAttributes
                .Include(a => a.Product)
                .Include(a => a.Attribute)
                .ByProduct(productId)
                .SingleOrDefault(a => a.Id == attributeId);

            if (attribute is null)
            {
                return null;
            }

            var model = new ProductAttributeModel
            {
                Attribute = new ProductAttributeModel.AttributeInfo
                {
                    Id = attribute.Attribute.Id,
                    Name = attribute.Attribute.Name
                },
                Value = attribute.Value
            };

            return model;
        }

        public async Task CreateNewProductAttribute(Guid productId, ProductAttributeModel model) => await Commands.AddAttributeToProduct(productId, model.Attribute.Id, model.Value);

        public async Task DeleteProductAttribute(Guid productId, Guid attributeId) => await Commands.RemoveProductAttribute(productId, attributeId);
    }
}
