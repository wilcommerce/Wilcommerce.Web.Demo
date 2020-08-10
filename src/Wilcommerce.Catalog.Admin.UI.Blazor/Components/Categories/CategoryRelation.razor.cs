using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Categories;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.Categories
{
    public partial class CategoryRelation
    {
        [Inject]
        public CategoriesHttpClient Client { get; set; }

        [Parameter]
        public CategoryDescriptorModel ParentCategory { get; set; }

        [Parameter]
        public IList<CategoryDescriptorModel> Children { get; set; }

        [Parameter]
        public EventCallback<CategoryDescriptorModel> OnParentSet { get; set; }

        [Parameter]
        public EventCallback<CategoryDescriptorModel> OnParentRemoved { get; set; }

        [Parameter]
        public EventCallback<CategoryDescriptorModel> OnChildAdded { get; set; }

        [Parameter]
        public EventCallback<CategoryDescriptorModel> OnChildRemoved { get; set; }

        [Parameter]
        public bool Readonly { get; set; }

        bool parentEditingEnabled;
        bool childrenEditingEnabled;

        EditContext parentContext;
        EditContext childrenContext;

        private CategoryDescriptorModel _originalParent;
        private bool _parentIsEmpty;

        private Func<CategoryDescriptorModel, string> displayValue = (category) => category.IsEmpty ? "Choose a category" : $"{category.Code} - {category.Name}";

        private IEnumerable<CategoryDescriptorModel> categories = new CategoryDescriptorModel[0];

        private CategoryDescriptorModel _child = new CategoryDescriptorModel();

        async Task SetParentCategory() => await OnParentSet.InvokeAsync(ParentCategory);

        async Task RemoveParentCategory()
        {
            if (!_parentIsEmpty)
            {
                await OnParentRemoved.InvokeAsync(ParentCategory);
            }
        }

        async Task AddChild()
        {
            await OnChildAdded.InvokeAsync(_child);
            _child = new CategoryDescriptorModel();
        }

        async Task RemoveChild(CategoryDescriptorModel child) => await OnChildRemoved.InvokeAsync(child);

        protected override Task OnInitializedAsync()
        {
            parentContext = new EditContext(ParentCategory);
            childrenContext = new EditContext(Children);

            parentEditingEnabled = !Readonly;
            childrenEditingEnabled = !Readonly;

            _parentIsEmpty = ParentCategory.IsEmpty;
            _originalParent = new CategoryDescriptorModel
            {
                Code = ParentCategory.Code,
                Id = ParentCategory.Id,
                Name = ParentCategory.Name
            };

            return base.OnInitializedAsync();
        }

        async Task<IEnumerable<CategoryDescriptorModel>> SearchCategories(string query)
        {
            categories = await Client.SearchCategoriesByText(query);
            return categories;
        }

        void EnableParentEditing() => parentEditingEnabled = true;

        void EnableChildrenEditing() => childrenEditingEnabled = true;

        void CancelParent()
        {
            ParentCategory = new CategoryDescriptorModel
            {
                Code = _originalParent.Code,
                Id = _originalParent.Id,
                Name = _originalParent.Name
            };

            if (Readonly)
            {
                parentEditingEnabled = false;
            }

            StateHasChanged();
        }

        void CancelChild()
        {
            _child = new CategoryDescriptorModel();

            if (Readonly)
            {
                childrenEditingEnabled = false;
            }

            StateHasChanged();
        }
    }
}
