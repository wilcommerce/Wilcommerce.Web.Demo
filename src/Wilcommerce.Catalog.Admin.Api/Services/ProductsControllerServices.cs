using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Products;
using Wilcommerce.Catalog.Commands;
using Wilcommerce.Catalog.ReadModels;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Api.Services
{
    public class ProductsControllerServices : IProductsControllerServices
    {
        public ICatalogDatabase Database { get; }
        public IProductCommands Commands { get; }

        public ProductsControllerServices(ICatalogDatabase database, IProductCommands commands)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
            Commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public ProductListModel GetProducts(ProductListQueryModel queryModel)
        {
            if (queryModel is null)
            {
                queryModel = new ProductListQueryModel();
            }

            var productsQuery = Database.Products.AsNoTracking();
            if (queryModel.ActiveOnly)
            {
                productsQuery = productsQuery.Active();
            }
            if (queryModel.AvailableOnly)
            {
                productsQuery = productsQuery.Available();
            }
            if (!string.IsNullOrWhiteSpace(queryModel.Query))
            {
                productsQuery = productsQuery
                    .Where(p => p.Name.Contains(queryModel.Query) || p.Description.Contains(queryModel.Query) || p.EanCode.Contains(queryModel.Query) || p.Sku.Contains(queryModel.Query));
            }

            int skip = (queryModel.Page - 1) * queryModel.Size;

            int total = productsQuery.Count();
            var items = productsQuery
                .OrderBy(p => p.Name)
                .OrderBy(p => p.EanCode)
                .OrderBy(p => p.Sku)
                .Select(p => new ProductListModel.ListItem
                {
                    Id = p.Id,
                    Deleted = p.Deleted,
                    EanCode = p.EanCode,
                    IsOnSale = p.IsOnSale,
                    Name = p.Name,
                    OnSaleFrom = p.OnSaleFrom,
                    OnSaleTo = p.OnSaleTo,
                    Price = p.Price,
                    Sku = p.Sku,
                    UnitInStock = p.UnitInStock
                }).Skip(skip).Take(queryModel.Size).ToArray();

            double pages = total / queryModel.Page;

            var model = new ProductListModel
            {
                Total = total,
                CurrentPage = pages == 0 ? 0 : queryModel.Page,
                TotalPages = Convert.ToInt32(Math.Ceiling(pages)),
                Items = items
            };

            return model;
        }

        public async Task<Guid> CreateNewProduct(ProductInfoModel model)
        {
            var productId = await Commands.CreateNewProduct(
                model.EanCode,
                model.Sku,
                model.Name,
                model.Url,
                model.Price,
                model.Description,
                model.UnitInStock,
                model.IsOnSale,
                model.OnSaleFrom,
                model.OnSaleTo);

            return productId;
        }

        public ProductDetailModel GetProductDetail(Guid productId)
        {
            var product = Database.Products.SingleOrDefault(p => p.Id == productId);
            if (product is null)
            {
                return null;
            }

            var model = new ProductDetailModel
            {
                Id = product.Id,
                Details = new ProductInfoModel
                {
                    Description = product.Description,
                    EanCode = product.EanCode,
                    IsOnSale = product.IsOnSale,
                    Name = product.Name,
                    OnSaleFrom = product.OnSaleFrom,
                    OnSaleTo = product.OnSaleTo,
                    Price = product.Price,
                    Sku = product.Sku,
                    UnitInStock = product.UnitInStock,
                    Url = product.Url
                },
                Seo = product.Seo,
                Brand = new ProductBrandModel
                {
                    BrandId = product.Vendor?.Id ?? Guid.Empty,
                    Name = product.Vendor?.Name
                }
            };

            return model;
        }

        public async Task UpdateProductInfo(Guid productId, ProductInfoModel model)
        {
            await Commands.UpdateProductInfo(
                productId,
                model.EanCode,
                model.Sku,
                model.Name,
                model.Url,
                model.Price,
                model.Description,
                model.UnitInStock,
                model.IsOnSale,
                model.OnSaleFrom,
                model.OnSaleTo);
        }

        public async Task UpdateProductSeoData(Guid productId, SeoData model) => await Commands.SetProductSeo(productId, model);

        public async Task DeleteProduct(Guid productId) => await Commands.DeleteProduct(productId);

        public async Task RestoreProduct(Guid productId) => await Commands.RestoreProduct(productId);

        public async Task SetProductVendor(Guid productId, ProductBrandModel model) => await Commands.SetProductVendor(productId, model.BrandId);

        public IEnumerable<ProductVariantModel> GetProductVariants(Guid productId)
        {
            var variants = Database.Products
                .VariantsOf(productId)
                .OrderBy(p => p.Name)
                .OrderBy(p => p.EanCode)
                .OrderBy(p => p.Sku)
                .Select(p => new ProductVariantModel
                {
                    Id = p.Id,
                    EanCode = p.EanCode,
                    Sku = p.Sku,
                    Name = p.Name,
                    Price = p.Price
                }).ToArray();

            return variants;
        }

        public async Task AddProductVariant(Guid productId, ProductVariantModel model) => await Commands.AddProductVariant(productId, model.Name, model.EanCode, model.Sku, model.Price);

        public async Task ChangeProductVariant(Guid productId, Guid variantId, ProductVariantModel model) => await Commands.ChangeProductVariant(productId, variantId, model.Name, model.EanCode, model.Sku, model.Price);

        public async Task DeleteProductVariant(Guid productId, Guid variantId) => await Commands.RemoveProductVariant(productId, variantId);
    }
}
