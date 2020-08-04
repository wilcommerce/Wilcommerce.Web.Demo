using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wilcommerce.Catalog.Admin.Api.Services;

namespace Wilcommerce.Catalog.Admin.Api.Controllers
{
    [Route("api/admin/catalog/products/{productId}/categories")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        public IProductCategoriesControllerServices ControllerServices { get; }

        private readonly ILogger<ProductCategoriesController> _logger;

        public ProductCategoriesController(IProductCategoriesControllerServices controllerServices, ILogger<ProductCategoriesController> logger)
        {
            ControllerServices = controllerServices ?? throw new ArgumentNullException(nameof(controllerServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
