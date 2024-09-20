using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Order.Infrastructure;

namespace WS.Order.ApplicationService.Common
{
    public abstract class OrderServiceBase
    {
        protected readonly ILogger _logger;
        protected readonly OrderDbContext _orderDbContext;
        protected OrderServiceBase(ILogger logger, OrderDbContext orderDbContext)
        {
            _logger = logger;
            _orderDbContext = orderDbContext;
        }
    }
}
