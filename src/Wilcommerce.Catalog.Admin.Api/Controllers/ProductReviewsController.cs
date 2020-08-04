using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wilcommerce.Catalog.Admin.Api.Services;

namespace Wilcommerce.Catalog.Admin.Api.Controllers
{
    [Route("api/admin/catalog/products/{productId}/reviews")]
    [ApiController]
    public class ProductReviewsController : ControllerBase
    {
        public IProductReviewsControllerServices ControllerServices { get; }

        private readonly ILogger<ProductReviewsController> _logger;

        public ProductReviewsController(IProductReviewsControllerServices controllerServices, ILogger<ProductReviewsController> logger)
        {
            ControllerServices = controllerServices ?? throw new ArgumentNullException(nameof(controllerServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
