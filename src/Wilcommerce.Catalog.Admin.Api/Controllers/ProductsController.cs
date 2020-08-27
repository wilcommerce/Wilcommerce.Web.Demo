using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wilcommerce.Catalog.Admin.Api.Services;
using Wilcommerce.Catalog.Admin.Models.Products;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Api.Controllers
{
    [Route("api/admin/catalog/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductsControllerServices ControllerServices { get; }

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductsControllerServices controllerServices, ILogger<ProductsController> logger)
        {
            ControllerServices = controllerServices ?? throw new ArgumentNullException(nameof(controllerServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult Get([FromQuery]ProductListQueryModel queryModel = null)
        {
            var model = ControllerServices.GetProducts(queryModel);
            _logger.LogInformation($"Found {model.Items.Count()} products of {model.Total}");

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            var model = ControllerServices.GetProductDetail(id);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductInfoModel model)
        {
            var productId = await ControllerServices.CreateNewProduct(model);
            return CreatedAtAction(nameof(Get), new { id = productId }, productId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]ProductInfoModel model)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            await ControllerServices.UpdateProductInfo(id, model);
            return Ok();
        }

        [HttpPatch("{id}/seo")]
        public async Task<IActionResult> PatchSeo(Guid id, [FromBody]SeoData model)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            await ControllerServices.UpdateProductSeoData(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            await ControllerServices.DeleteProduct(id);
            return Ok();
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> PatchRestore(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            await ControllerServices.RestoreProduct(id);
            return Ok();
        }

        [HttpPatch("{id}/vendor")]
        public async Task<IActionResult> PatchVendor(Guid id, [FromBody]ProductBrandModel model)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            await ControllerServices.SetProductVendor(id, model);
            return Ok();
        }

        [HttpGet("{id}/variants")]
        public IActionResult GetVariants(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            var variants = ControllerServices.GetProductVariants(id);
            return Ok(variants);
        }

        [HttpPost("{id}/variants")]
        public async Task<IActionResult> PostVariant(Guid id, [FromBody]ProductVariantModel model)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            await ControllerServices.AddProductVariant(id, model);
            return Ok();
        }

        [HttpPut("{id}/variants/{variantId}")]
        public async Task<IActionResult> PutVariant(Guid id, Guid variantId, [FromBody]ProductVariantModel model)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            if (variantId == Guid.Empty)
            {
                return BadRequest(nameof(variantId));
            }

            await ControllerServices.ChangeProductVariant(id, variantId, model);
            return Ok();
        }

        [HttpDelete("{id}/variants/{variantId}")]
        public async Task<IActionResult> DeleteVariant(Guid id, Guid variantId)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(nameof(id));
            }

            if (variantId == Guid.Empty)
            {
                return BadRequest(nameof(variantId));
            }

            await ControllerServices.DeleteProductVariant(id, variantId);
            return Ok();
        }
    }
}
