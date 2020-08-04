using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wilcommerce.Catalog.Admin.Api.Services;

namespace Wilcommerce.Catalog.Admin.Api.Controllers
{
    [Route("api/admin/catalog/products/{productId}/images")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        public IProductImagesControllerServices ControllerServices { get; }

        private readonly ILogger<ProductImagesController> _logger;

        public ProductImagesController(IProductImagesControllerServices controllerServices, ILogger<ProductImagesController> logger)
        {
            ControllerServices = controllerServices ?? throw new ArgumentNullException(nameof(controllerServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
