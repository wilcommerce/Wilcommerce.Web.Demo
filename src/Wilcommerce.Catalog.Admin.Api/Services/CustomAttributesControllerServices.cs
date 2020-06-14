using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;
using Wilcommerce.Catalog.Commands;
using Wilcommerce.Catalog.ReadModels;

namespace Wilcommerce.Catalog.Admin.Api.Services
{
    public class CustomAttributesControllerServices : ICustomAttributesControllerServices
    {
        public ICatalogDatabase Database { get; }

        public ICustomAttributesCommands Commands { get; }

        public CustomAttributesControllerServices(ICatalogDatabase database, ICustomAttributesCommands commands)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
            Commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public CustomAttributeListModel GetCustomAttributes(CustomAttributeListQueryModel queryModel)
        {
            if (queryModel is null)
            {
                queryModel = new CustomAttributeListQueryModel();
            }

            var customAttributesQuery = Database.CustomAttributes;
            if (queryModel.ActiveOnly)
            {
                customAttributesQuery = customAttributesQuery.Active();
            }
            if (!string.IsNullOrWhiteSpace(queryModel.Query))
            {
                customAttributesQuery = customAttributesQuery.Where(c => c.Name.Contains(queryModel.Query));
            }

            int skip = (queryModel.Page - 1) * queryModel.Size;

            int total = customAttributesQuery.Count();
            var items = customAttributesQuery
                .OrderBy(c => c.Name)
                .Select(c => new CustomAttributeListModel.ListItem
                {
                    Id = c.Id,
                    Name = c.Name,
                    DataType = c.DataType,
                    Deleted = c.Deleted,
                    UnitOfMeasure = c.UnitOfMeasure
                }).ToArray();

            double pages = total / queryModel.Page;

            var model = new CustomAttributeListModel
            {
                Total = total,
                CurrentPage = pages == 0 ? 0 : queryModel.Page,
                TotalPages = Convert.ToInt32(Math.Ceiling(pages)),
                Items = items
            };

            return model;
        }

        public async Task<Guid> CreateNewCustomAttribute(CustomAttributeInfoModel model)
        {
            var customAttributeId = await Commands.CreateNewCustomAttribute(model.Name, model.Type, model.Description, model.UnitOfMeasure, model.Values);
            return customAttributeId;
        }

        public CustomAttributeDetailModel GetCustomAttributeDetail(Guid customAttributeId)
        {
            var customAttribute = Database.CustomAttributes
                .SingleOrDefault(c => c.Id == customAttributeId);

            if (customAttribute is null)
            {
                return null;
            }

            return new CustomAttributeDetailModel
            {
                Id = customAttributeId,
                Details = new CustomAttributeInfoModel
                {
                    Description = customAttribute.Description,
                    Name = customAttribute.Name,
                    Type = customAttribute.DataType,
                    UnitOfMeasure = customAttribute.UnitOfMeasure,
                    Values = customAttribute.Values?.ToList() ?? new List<object>()
                }
            };
        }

        public async Task UpdateCustomAttribute(Guid customAttributeId, CustomAttributeInfoModel model)
        {
            await Commands.UpdateCustomAttribute(
                customAttributeId,
                model.Name,
                model.Type,
                model.Description,
                model.UnitOfMeasure,
                model.Values);
        }

        public async Task DeleteCustomAttribute(Guid customAttributeId) => await Commands.DeleteCustomAttribute(customAttributeId);

        public async Task RestoreCustomAttribute(Guid customAttributeId) => await Commands.RestoreCustomAttribute(customAttributeId);
    }
}
