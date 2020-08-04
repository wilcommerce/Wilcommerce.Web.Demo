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
    }
}
