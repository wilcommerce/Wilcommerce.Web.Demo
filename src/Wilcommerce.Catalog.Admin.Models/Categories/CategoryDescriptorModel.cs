using System;

namespace Wilcommerce.Catalog.Admin.Models.Categories
{
    public class CategoryDescriptorModel
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool IsEmpty => this == new CategoryDescriptorModel();

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            var model = obj as CategoryDescriptorModel;
            if (model is null)
            {
                return false;
            }

            return Id == model.Id && Code == model.Code && Name == model.Name;
        }

        public override int GetHashCode() => base.GetHashCode();

        public static bool operator==(CategoryDescriptorModel c1, CategoryDescriptorModel c2)
        {
            if (ReferenceEquals(c1, null))
            {
                return ReferenceEquals(null, c2);
            }

            return c1.Equals(c2);
        }

        public static bool operator !=(CategoryDescriptorModel c1, CategoryDescriptorModel c2) => !(c1 == c2);
    }
}
