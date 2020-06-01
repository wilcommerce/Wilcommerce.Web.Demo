﻿using System;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Api.Services
{
    public interface IBrandsControllerServices
    {
        BrandListModel GetBrands(BrandListQueryModel queryModel);
        
        Task<Guid> CreateNewBrand(BrandInfoModel model);
        
        BrandDetailModel GetBrandDetail(Guid brandId);

        Task UpdateBrandInfo(Guid brandId, BrandInfoModel model);
        
        Task UpdateBrandSeoData(Guid brandId, SeoData model);
        
        Task DeleteBrand(Guid brandId);
        
        Task RestoreBrand(Guid brandId);
    }
}