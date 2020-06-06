using System;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;

namespace Wilcommerce.Catalog.Admin.Api.Services
{
    public interface ICustomAttributesControllerServices
    {
        CustomAttributeListModel GetCustomAttributes(CustomAttributeListQueryModel queryModel);

        Task<Guid> CreateNewCustomAttribute(CustomAttributeInfoModel model);

        CustomAttributeDetailModel GetCustomAttributeDetail(Guid customAttributeId);

        Task UpdateCustomAttribute(Guid customAttributeId, CustomAttributeInfoModel model);

        Task DeleteCustomAttribute(Guid customAttributeId);

        Task RestoreCustomAttribute(Guid customAttributeId);
    }
}
