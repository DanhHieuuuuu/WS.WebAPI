using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Product.Infrastructure;

namespace WS.Product.ApplicationService.Common
{
    public abstract class ProductServiceBase
    {
        protected readonly ILogger _logger;
        protected readonly ProductDbContext _productDbContext;

        protected ProductServiceBase(ILogger logger, ProductDbContext productDbContext)
        {
            _logger = logger;
             _productDbContext = productDbContext;
        }
    }
}
