using System;

namespace Wilcommerce.Catalog.Admin.Models.CustomAttributes
{
    public class CustomAttributeDetailModel
    {
        public Guid Id { get; set; }

        public CustomAttributeInfoModel Details { get; set; }
    }
}
