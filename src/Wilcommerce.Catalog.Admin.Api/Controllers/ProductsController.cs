using System;
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
            _logger.LogInformation("Found {itemsNumber} products of {itemsTotal}", model.Items.Count(), model.Total);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(id));
            }

            var model = ControllerServices.GetProductDetail(id);
            _logger.LogInformation("Product found with id {productId}", id);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductInfoModel model)
        {
            var productId = await ControllerServices.CreateNewProduct(model);
            _logger.LogInformation("New product created with id {productId}", productId);

            return CreatedAtAction(nameof(Get), new { id = productId }, productId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]ProductInfoModel model)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.UpdateProductInfo(id, model);
            _logger.LogInformation("Info updated for product {productId}", id);

            return Ok();
        }

        [HttpPatch("{id}/seo")]
        public async Task<IActionResult> PatchSeo(Guid id, [FromBody]SeoData model)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.UpdateProductSeoData(id, model);
            _logger.LogInformation("SEO data updated for product with id {productId}", id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.DeleteProduct(id);
            _logger.LogInformation("Product {productId} deleted", id);

            return Ok();
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> PatchRestore(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.RestoreProduct(id);
            _logger.LogInformation("Product {productId} restored", id);

            return Ok();
        }

        [HttpPatch("{id}/vendor")]
        public async Task<IActionResult> PatchVendor(Guid id, [FromBody]ProductBrandModel model)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.SetProductVendor(id, model);
            _logger.LogInformation("Vendor {vendorId} set for product {productId}", model.BrandId, id);

            return Ok();
        }

        [HttpGet("{id}/variants")]
        public IActionResult GetVariants(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(id));
            }

            var variants = ControllerServices.GetProductVariants(id);
            _logger.LogInformation("Found {variantsNumber} for product {productId}", variants.Count(), id);

            return Ok(variants);
        }

        [HttpPost("{id}/variants")]
        public async Task<IActionResult> PostVariant(Guid id, [FromBody]ProductVariantModel model)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.AddProductVariant(id, model);
            _logger.LogInformation("Add variant to product {productId}", id);

            return Ok();
        }

        [HttpPut("{id}/variants/{variantId}")]
        public async Task<IActionResult> PutVariant(Guid id, Guid variantId, [FromBody]ProductVariantModel model)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(id));
            }

            if (variantId == Guid.Empty)
            {
                _logger.LogError("Empty variant id");
                return BadRequest(nameof(variantId));
            }

            await ControllerServices.ChangeProductVariant(id, variantId, model);
            _logger.LogInformation("Variant {variantId} updated for product {productId}", variantId, id);

            return Ok();
        }

        [HttpDelete("{id}/variants/{variantId}")]
        public async Task<IActionResult> DeleteVariant(Guid id, Guid variantId)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty product id");
                return BadRequest(nameof(id));
            }

            if (variantId == Guid.Empty)
            {
                _logger.LogError("Empty variant id");
                return BadRequest(nameof(variantId));
            }

            await ControllerServices.DeleteProductVariant(id, variantId);
            _logger.LogInformation("Deleted variant {variantId} from product {productId}", variantId, id);

            return Ok();
        }
    }
}
