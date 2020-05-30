using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Api.Services;
using Wilcommerce.Catalog.Admin.Models.Brands;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Api.Controllers
{
    [Route("admin/api/catalog/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        public IBrandsControllerServices ControllerServices { get; }

        private readonly ILogger<BrandsController> _logger;

        public BrandsController(IBrandsControllerServices controllerServices, ILogger<BrandsController> logger)
        {
            ControllerServices = controllerServices ?? throw new ArgumentNullException(nameof(controllerServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult Get([FromQuery] bool activeOnly = true)
        {
            var brands = ControllerServices.GetBrands(activeOnly);
            _logger.LogInformation($"Found {brands.Count()} brands");

            return Ok(brands);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]BrandInfoModel model)
        {
            var brandId = await ControllerServices.CreateNewBrand(model);
            _logger.LogInformation($"New brand created with id {brandId}");

            return CreatedAtAction(nameof(Get), new { id = brandId }, model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty brand id");
                return BadRequest(nameof(id));
            }

            var model = ControllerServices.GetBrandDetail(id);
            _logger.LogInformation($"Brand found with id {id}");

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromForm]BrandInfoModel model)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty brand id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.UpdateBrandInfo(id, model);
            _logger.LogInformation($"Info updated for brand with {id}");

            return Ok();
        }

        [HttpPatch("{id}/seo")]
        public async Task<IActionResult> PatchSeo(Guid id, [FromBody]SeoData model)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty brand id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.UpdateBrandSeoData(id, model);
            _logger.LogInformation($"SEO data updated for brand with {id}");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty brand id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.DeleteBrand(id);
            _logger.LogInformation($"Brand with id {id} deleted");

            return Ok();
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> PatchRestore(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Empty brand id");
                return BadRequest(nameof(id));
            }

            await ControllerServices.RestoreBrand(id);
            _logger.LogInformation($"Brand with id {id} restored");

            return Ok();
        }
    }
}
