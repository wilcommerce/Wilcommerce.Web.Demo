using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.ProductAttributes;

namespace Wilcommerce.Catalog.Admin.Api.Services
{
    public interface IProductAttributesControllerServices
    {
        IEnumerable<ProductAttributeListModel> GetProductAttributes(Guid productId);

        ProductAttributeModel GetProductAttributeDetail(Guid productId, Guid attributeId);

        Task CreateNewProductAttribute(Guid productId, ProductAttributeModel model);

        Task DeleteProductAttribute(Guid productId, Guid attributeId);
    }
}
