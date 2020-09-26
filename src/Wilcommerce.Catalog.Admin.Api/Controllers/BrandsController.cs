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
    [Route("api/admin/catalog/[controller]")]
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
        public IActionResult Get([FromQuery]BrandListQueryModel queryModel)
        {
            var model = ControllerServices.GetBrands(queryModel);
            _logger.LogInformation("Found {itemsNumber} brands of {itemsTotal}", model.Items.Count(), model.Total);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]BrandInfoModel model)
        {
            var brandId = await ControllerServices.CreateNewBrand(model);
            _logger.LogInformation("New brand created with id {brandId}", brandId);

            return CreatedAtAction(nameof(Get), new { id = brandId }, brandId);
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
            _logger.LogInformation("Brand found with id {brandId}", id);

            return Ok(model);
        }

        [HttpGet("{id}/logo")]
        public IActionResult GetLogo(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var logo = ControllerServices.GetBrandLogo(id);
            if (logo == null)
            {
                return NoContent();
            }

            return File(logo.Data, logo.MimeType);
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
            _logger.LogInformation("Info updated for brand with {brandId}", id);

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
            _logger.LogInformation("SEO data updated for brand with id {brandId}", id);

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
            _logger.LogInformation("Brand with id {brandId} deleted", id);

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
            _logger.LogInformation("Brand with id {brandId} restored", id);

            return Ok();
        }

        [HttpGet("search")]
        public IActionResult GetSearch(string q)
        {
            var brands = ControllerServices.SearchBrandsByText(q);
            return Ok(brands);
        }
    }
}
