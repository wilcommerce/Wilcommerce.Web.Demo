using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wilcommerce.Catalog.Admin.Api.Services;

namespace Wilcommerce.Catalog.Admin.Api.Controllers
{
    [Route("api/admin/catalog/products/{productId}/tierprices")]
    [ApiController]
    public class ProductTierPricesController : ControllerBase
    {
        public IProductTierPricesControllerServices ControllerServices { get; }

        private readonly ILogger<ProductTierPricesController> _logger;

        public ProductTierPricesController(IProductTierPricesControllerServices controllerServices, ILogger<ProductTierPricesController> logger)
        {
            ControllerServices = controllerServices ?? throw new ArgumentNullException(nameof(controllerServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
