using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Products;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Api.Services
{
    public interface IProductsControllerServices
    {
        ProductListModel GetProducts(ProductListQueryModel queryModel);
        
        Task<Guid> CreateNewProduct(ProductInfoModel model);
        
        ProductDetailModel GetProductDetail(Guid productId);
        
        Task UpdateProductInfo(Guid productId, ProductInfoModel model);
        
        Task UpdateProductSeoData(Guid productId, SeoData model);
        
        Task DeleteProduct(Guid productId);
        
        Task RestoreProduct(Guid productId);
        
        Task SetProductVendor(Guid productId, ProductBrandModel model);
        
        IEnumerable<ProductVariantModel> GetProductVariants(Guid productId);
        
        Task AddProductVariant(Guid productId, ProductVariantModel model);

        Task ChangeProductVariant(Guid productId, Guid variantId, ProductVariantModel model);
        
        Task DeleteProductVariant(Guid productId, Guid variantId);
    }
}
