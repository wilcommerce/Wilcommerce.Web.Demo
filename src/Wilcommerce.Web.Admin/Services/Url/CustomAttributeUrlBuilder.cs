using System;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;

namespace Wilcommerce.Web.Admin.Services.Url
{
    public class CustomAttributeUrlBuilder : IUrlBuilder
    {
        public string ApiPrefix => "/api/admin/catalog";

        public string ResourceName => "customattributes";

        public string CustomAttributeListUrl(CustomAttributeListQueryModel queryModel)
        {
            string url = $"{ApiPrefix}/{ResourceName}";
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

        public string CustomAttributeDetailUrl(Guid attributeId) => $"{ApiPrefix}/{ResourceName}/{attributeId}";

        public string CreateNewCustomAttributeUrl() => $"{ApiPrefix}/{ResourceName}";

        public string UpdateCustomAttributeUrl(Guid attributeId) => $"{ApiPrefix}/{ResourceName}/{attributeId}";

        public string DeleteCustomAttributeUrl(Guid attributeId) => $"{ApiPrefix}/{ResourceName}/{attributeId}";

        public string RestoreCustomAttributeUrl(Guid attributeId) => $"{ApiPrefix}/{ResourceName}/{attributeId}/restore";
    }
}
