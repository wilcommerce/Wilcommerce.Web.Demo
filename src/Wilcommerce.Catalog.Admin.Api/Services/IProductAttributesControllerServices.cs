using System;
using System.Collections.Generic;
using System.Text;
using Wilcommerce.Catalog.Admin.Models.ProductAttributes;

namespace Wilcommerce.Catalog.Admin.Api.Services
{
    public interface IProductAttributesControllerServices
    {
        IEnumerable<ProductAttributeListModel> GetProductAttributes(Guid productId);
    }
}
