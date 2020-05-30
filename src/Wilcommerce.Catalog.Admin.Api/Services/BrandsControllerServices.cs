using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;
using Wilcommerce.Catalog.Commands;
using Wilcommerce.Catalog.ReadModels;
using Wilcommerce.Core.Common.Models;
using Wilcommerce.Web.AspNetCore.Http;

namespace Wilcommerce.Catalog.Admin.Api.Services
{
    public class BrandsControllerServices : IBrandsControllerServices
    {
        public ICatalogDatabase Database { get; }

        public IBrandCommands Commands { get; }

        public BrandsControllerServices(ICatalogDatabase database, IBrandCommands commands)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
            Commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public IEnumerable<BrandListItemModel> GetBrands(bool activeOnly)
        {
            var brandsQuery = Database.Brands;
            if (activeOnly)
            {
                brandsQuery = brandsQuery.Active();
            }

            var brands = Database.Brands
                .OrderBy(b => b.Name)
                .Select(b => new BrandListItemModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Url = b.Url,
                    Description = b.Description
                }).ToArray();

            return brands;
        }

        public async Task<Guid> CreateNewBrand(BrandInfoModel model)
        {
            Image brandLogo = null;
            if (model.Image != null && model.Image.Length > 0)
            {
                brandLogo = new Image
                {
                    MimeType = model.Image.ContentType,
                    Data = model.Image.ToByteArray()
                };
            }

            var brandId = await Commands.CreateNewBrand(model.Name, model.Url, model.Description, brandLogo);
            return brandId;
        }

        public BrandDetailModel GetBrandDetail(Guid brandId)
        {
            var brand = Database.Brands
                .SingleOrDefault(b => b.Id == brandId);

            if (brand is null)
            {
                return null;
            }

            return new BrandDetailModel
            {
                Id = brandId,
                Details = new BrandInfoModel
                {
                    Description = brand.Description,
                    Name = brand.Name,
                    Url = brand.Url
                },
                Seo = brand.Seo
            };
        }

        public async Task UpdateBrandInfo(Guid brandId, BrandInfoModel model)
        {
            Image brandLogo = null;
            if (model.Image != null && model.Image.Length > 0)
            {
                brandLogo = new Image
                {
                    MimeType = model.Image.ContentType,
                    Data = model.Image.ToByteArray()
                };
            }

            await Commands.UpdateBrandInfo(brandId, model.Name, model.Url, model.Description, brandLogo);
        }

        public async Task UpdateBrandSeoData(Guid brandId, SeoData model) => await Commands.SetBrandSeoData(brandId, model);

        public async Task DeleteBrand(Guid brandId) => await Commands.DeleteBrand(brandId);

        public async Task RestoreBrand(Guid brandId) => await Commands.RestoreBrand(brandId);
    }
}
