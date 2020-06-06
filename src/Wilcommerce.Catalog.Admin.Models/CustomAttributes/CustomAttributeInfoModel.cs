using System;
using System.Collections.Generic;
using System.Text;

namespace Wilcommerce.Catalog.Admin.Models.CustomAttributes
{
    public class CustomAttributeInfoModel
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string UnitOfMeasure { get; set; }

        public IList<object> Values { get; set; }

        public CustomAttributeInfoModel()
        {
            Values = new List<object>();
        }

        public enum DataTypes
        {
            String,
            Number,
            Date,
            DateTime,
            Time,
            Boolean,
            Color
        }
    }
}
