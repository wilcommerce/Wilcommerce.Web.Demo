using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wilcommerce.Catalog.Admin.Api.Services;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;

namespace Wilcommerce.Catalog.Admin.Api.Controllers
{
    [Route("api/admin/catalog/[controller]")]
    [ApiController]
    public class CustomAttributesController : ControllerBase
    {
        public ICustomAttributesControllerServices ControllerServices { get; }

        private readonly ILogger<CustomAttributesController> _logger;

        public CustomAttributesController(ICustomAttributesControllerServices controllerServices, ILogger<CustomAttributesController> logger)
        {
            ControllerServices = controllerServices ?? throw new ArgumentNullException(nameof(controllerServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult Get([FromQuery]CustomAttributeListQueryModel queryModel = null)
        {
            var model = ControllerServices.GetCustomAttributes(queryModel);
            _logger.LogInformation("Found {itemsNumber} custom attributes of {itemsTotal}", model.Items.Count(), model.Total);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CustomAttributeInfoModel model)
        {
            var customAttributeId = await ControllerServices.CreateNewCustomAttribute(model);
            _logger.LogInformation("New custom attribute created with id {customAttributeId}", customAttributeId);

            return CreatedAtAction(nameof(Get), new { id = customAttributeId }, customAttributeId);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty attribute id");
                return BadRequest(nameof(id));
            }

            var model = ControllerServices.GetCustomAttributeDetail(id);
            _logger.LogInformation("Attribute found with id {customAttributeId}", id);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]CustomAttributeInfoModel model)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty attribute id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.UpdateCustomAttribute(id, model);
            _logger.LogInformation("Custom attribute {customAttributeId} updated", id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty attribute id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.DeleteCustomAttribute(id);
            _logger.LogInformation("Custom attribute {customAttributeId} deleted", id);

            return Ok();
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> PatchRestore(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty attribute id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.RestoreCustomAttribute(id);
            _logger.LogInformation("Custom attribute {customAttributeId} restored", id);

            return Ok();
        }

        [HttpGet("search")]
        public IActionResult GetSearch(string query = null)
        {
            var attributes = ControllerServices.SearchCustomAttributes(query);
            return Ok(attributes);
        }
    }
}
