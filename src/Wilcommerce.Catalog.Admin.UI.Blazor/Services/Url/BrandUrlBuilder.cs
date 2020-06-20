using System;
using Wilcommerce.Catalog.Admin.Models.Brands;
using Wilcommerce.Web.AspNetCore.Url;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Services.Url
{
    public class BrandUrlBuilder : IUrlBuilder
    {
        public string ApiPrefix => "/api/admin/catalog";

        public string ResourceName => "brands";

        public string BrandListUrl(BrandListQueryModel queryModel)
        {
            var url = $"{ApiPrefix}/{ResourceName}";
            if (queryModel != null)
            {
                url = $"{url}?activeOnly={queryModel.ActiveOnly}&page={queryModel.Page}&size={queryModel.Size}";
                if (!string.IsNullOrWhiteSpace(queryModel.Query))
                {
                    url = $"{url}&query={queryModel.Query}";
                }
            }

            return url;
        }

        public string BrandDetailUrl(Guid brandId) => $"{ApiPrefix}/{ResourceName}/{brandId}";

        public string CreateNewBrandUrl() => $"{ApiPrefix}/{ResourceName}";

        public string UpdateBrandInfoUrl(Guid brandId) => $"{ApiPrefix}/{ResourceName}/{brandId}";

        public string UpdateBrandSeoDataUrl(Guid brandId) => $"{ApiPrefix}/{ResourceName}/{brandId}/seo";

        public string DeleteBrandUrl(Guid brandId) => $"{ApiPrefix}/{ResourceName}/{brandId}";

        public string RestoreBrandUrl(Guid brandId) => $"{ApiPrefix}/{ResourceName}/{brandId}/restore";
    }
}
