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

        private Expression<Func<CategoryDescriptorModel, string>> displayValue = (category) => $"{category.Code} - {category.Name}";

        private IEnumerable<CategoryDescriptorModel> categories = new CategoryDescriptorModel[0];

        EditContext context;

        async Task SetParentCategory(CategoryDescriptorModel parent) => await OnParentSet.InvokeAsync(parent);

        async Task RemoveParentCategory() => await OnParentRemoved.InvokeAsync(ParentCategory);

        async Task AddChild(CategoryDescriptorModel child) => await OnChildAdded.InvokeAsync(child);

        async Task RemoveChild(CategoryDescriptorModel child) => await OnChildRemoved.InvokeAsync(child);

        protected override Task OnInitializedAsync()
        {
            context = new EditContext(ParentCategory);

            return base.OnInitializedAsync();
        }

        async Task SearchCategories(string query)
        {
            categories = await Client.SearchCategoriesByText(query);
            StateHasChanged();
        }
    }
}
