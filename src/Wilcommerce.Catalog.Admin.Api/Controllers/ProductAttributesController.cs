using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wilcommerce.Catalog.Admin.Api.Services;
using Wilcommerce.Catalog.Admin.Models.ProductAttributes;

namespace Wilcommerce.Catalog.Admin.Api.Controllers
{
    [Route("api/admin/catalog/products/{productId}/attributes")]
    [ApiController]
    public class ProductAttributesController : ControllerBase
    {
        public IProductAttributesControllerServices ControllerServices { get; }

        private readonly ILogger<ProductAttributesController> _logger;

        public ProductAttributesController(IProductAttributesControllerServices controllerServices, ILogger<ProductAttributesController> logger)
        {
            ControllerServices = controllerServices ?? throw new ArgumentNullException(nameof(controllerServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult Get(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(productId));
            }

            var model = ControllerServices.GetProductAttributes(productId);
            _logger.LogInformation("Found {itemsNumber} attributes for product {productId}", model.Count(), productId);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid productId, Guid id)
        {
            if (productId == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(productId));
            }

            if (id == Guid.Empty)
            {
                _logger.LogError("Empty attribute id");
                return BadRequest(nameof(id));
            }

            var model = ControllerServices.GetProductAttributeDetail(productId, id);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid productId, [FromBody]ProductAttributeModel model)
        {
            if (productId == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(productId));
            }

            await ControllerServices.CreateNewProductAttribute(productId, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid productId, Guid id)
        {
            if (productId == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(productId));
            }

            if (id == Guid.Empty)
            {
                _logger.LogError("Empty attribute id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.DeleteProductAttribute(productId, id);
            return Ok();
        }
    }
}
