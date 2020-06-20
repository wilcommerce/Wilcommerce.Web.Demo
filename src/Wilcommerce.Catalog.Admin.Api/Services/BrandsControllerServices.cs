using System;
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

        public BrandListModel GetBrands(BrandListQueryModel queryModel)
        {
            if (queryModel is null)
            {
                queryModel = new BrandListQueryModel();
            }

            var brandsQuery = Database.Brands;
            if (queryModel.ActiveOnly)
            {
                brandsQuery = brandsQuery.Active();
            }
            if (!string.IsNullOrWhiteSpace(queryModel.Query))
            {
                brandsQuery = brandsQuery.Where(b => b.Name.Contains(queryModel.Query) || b.Description.Contains(queryModel.Query));
            }

            int skip = (queryModel.Page - 1) * queryModel.Size;

            int total = brandsQuery.Count();
            var items = brandsQuery
                .OrderBy(b => b.Name)
                .Select(b => new BrandListModel.ListItem
                {
                    Id = b.Id,
                    Description = b.Description,
                    Name = b.Name,
                    Url = b.Url,
                    Deleted = b.Deleted
                }).Skip(skip).Take(queryModel.Size).ToArray();

            double pages = total / queryModel.Page;

            var model = new BrandListModel
            {
                Total = total,
                CurrentPage = pages == 0 ? 0 : queryModel.Page,
                TotalPages = Convert.ToInt32(Math.Ceiling(pages)),
                Items = items
            };

            return model;
        }

        public async Task<Guid> CreateNewBrand(BrandInfoModel model)
        {
            var brandLogo = new Image { Data = new byte[0] };
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
            var brandLogo = new Image { Data = new byte[0] };
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

        public Image GetBrandLogo(Guid brandId)
        {
            var logo = Database.Brands
                .SingleOrDefault(b => b.Id == brandId)?
                .Logo;

            return logo;
        }
    }
}
