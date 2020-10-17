using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wilcommerce.Catalog.Admin.Api.Services;

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

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(productId));
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid productId, Guid id)
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

            return Ok();
        }
    }
}
