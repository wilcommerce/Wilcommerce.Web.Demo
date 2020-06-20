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
            _logger.LogInformation($"Found {model.Items.Count()} categories of {model.Total}");

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var model = ControllerServices.GetCategoryDetail(id);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryInfoModel model)
        {
            var categoryId = await ControllerServices.CreateNewCategory(model);
            return CreatedAtAction(nameof(Get), new { id = categoryId }, categoryId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]CategoryInfoModel model)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            await ControllerServices.UpdateCategoryInfo(id, model);
            return Ok();
        }

        [HttpPatch("{id}/seo")]
        public async Task<IActionResult> PatchSeo(Guid id, [FromBody]SeoData model)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            await ControllerServices.UpdateCategorySeoData(id, model);
            return Ok();
        }

        [HttpPatch("{id}/child/{childId}")]
        public async Task<IActionResult> PatchChild(Guid id, Guid childId)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }
            if (childId == Guid.Empty)
            {
                return BadRequest(nameof(childId));
            }

            await ControllerServices.AddChildToCategory(id, childId);
            return Ok();
        }

        [HttpPatch("{id}/parent/{parentId}")]
        public async Task<IActionResult> PatchParent(Guid id, Guid parentId)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }
            if (parentId == Guid.Empty)
            {
                return BadRequest(nameof(parentId));
            }

            await ControllerServices.AddParentCategory(id, parentId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            await ControllerServices.DeleteCategory(id);
            return Ok();
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> PatchRestore(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            await ControllerServices.RestoreCategory(id);
            return Ok();
        }

        [HttpDelete("{id}/child/{childId}")]
        public async Task<IActionResult> DeleteChild(Guid id, Guid childId)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }
            if (childId == Guid.Empty)
            {
                return BadRequest(nameof(childId));
            }

            await ControllerServices.RemoveChildFromCategory(id, childId);
            return Ok();
        }

        [HttpDelete("{id}/parent/{parentId}")]
        public async Task<IActionResult> DeleteParent(Guid id, Guid parentId)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }
            if (parentId == Guid.Empty)
            {
                return BadRequest(nameof(parentId));
            }

            await ControllerServices.RemoveParentCategory(id, parentId);
            return Ok();
        }
    }
}
