using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wilcommerce.Catalog.Admin.Api.Services;
using Wilcommerce.Catalog.Admin.Models.Categories;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Api.Controllers
{
    [Route("api/admin/catalog/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public ICategoriesControllerServices ControllerServices { get; }

        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoriesControllerServices controllerServices, ILogger<CategoriesController> logger)
        {
            ControllerServices = controllerServices ?? throw new ArgumentNullException(nameof(controllerServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult Get([FromQuery]CategoryListQueryModel queryModel = null)
        {
            var model = ControllerServices.GetCategories(queryModel);
            _logger.LogInformation("Found {itemsNumber} categories of {itemsTotal}", model.Items.Count(), model.Total);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty category id");
                return BadRequest(nameof(id));
            }

            var model = ControllerServices.GetCategoryDetail(id);
            _logger.LogInformation("Category found with id {categoryId}", id);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryInfoModel model)
        {
            var categoryId = await ControllerServices.CreateNewCategory(model);
            _logger.LogInformation("New category created with id {categoryId}", categoryId);

            return CreatedAtAction(nameof(Get), new { id = categoryId }, categoryId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]CategoryInfoModel model)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty category id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.UpdateCategoryInfo(id, model);
            _logger.LogInformation("Info updated for category with {categoryId}", id);

            return Ok();
        }

        [HttpPatch("{id}/seo")]
        public async Task<IActionResult> PatchSeo(Guid id, [FromBody]SeoData model)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty category id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.UpdateCategorySeoData(id, model);
            _logger.LogInformation("SEO data updated for category with id {categoryId}", id);

            return Ok();
        }

        [HttpPatch("{id}/child/{childId}")]
        public async Task<IActionResult> PatchChild(Guid id, Guid childId)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty category id");
                return BadRequest(nameof(id));
            }
            if (childId == Guid.Empty)
            {
                _logger.LogError("Empty child category id");
                return BadRequest(nameof(childId));
            }

            await ControllerServices.AddChildToCategory(id, childId);
            _logger.LogInformation("Child {childId} added to category {categoryId}", childId, id);

            return Ok();
        }

        [HttpPatch("{id}/parent/{parentId}")]
        public async Task<IActionResult> PatchParent(Guid id, Guid parentId)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty category id");
                return BadRequest(nameof(id));
            }
            if (parentId == Guid.Empty)
            {
                _logger.LogError("Empty parent category id");
                return BadRequest(nameof(parentId));
            }

            await ControllerServices.AddParentCategory(id, parentId);
            _logger.LogInformation("Add parent {parentId} to category {categoryId}", parentId, id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty category id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.DeleteCategory(id);
            _logger.LogInformation("Category {categoryId} deleted", id);

            return Ok();
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> PatchRestore(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty category id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.RestoreCategory(id);
            _logger.LogInformation("Category {categoryId} restored", id);

            return Ok();
        }

        [HttpDelete("{id}/child/{childId}")]
        public async Task<IActionResult> DeleteChild(Guid id, Guid childId)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty category id");
                return BadRequest(nameof(id));
            }
            if (childId == Guid.Empty)
            {
                _logger.LogError("Empty child category id");
                return BadRequest(nameof(childId));
            }

            await ControllerServices.RemoveChildFromCategory(id, childId);
            _logger.LogInformation("Child {childId} removed from category {categoryId}", childId, id);

            return Ok();
        }

        [HttpDelete("{id}/parent/{parentId}")]
        public async Task<IActionResult> DeleteParent(Guid id, Guid parentId)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty category id");
                return BadRequest(nameof(id));
            }
            if (parentId == Guid.Empty)
            {
                _logger.LogError("Empty category id");
                return BadRequest(nameof(parentId));
            }

            await ControllerServices.RemoveParentCategory(id, parentId);
            _logger.LogInformation("Parent {parentId} removed from category {categoryId}", parentId, id);

            return Ok();
        }

        [HttpGet("search")]
        public IActionResult GetSearch(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest(nameof(query));
            }

            var categories = ControllerServices.SearchCategoriesByText(query);
            return Ok(categories);
        }
    }
}
