using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Auth.Infrastructure;

namespace WS.Auth.ApplicationService.Common
{
    public abstract class AuthServiceBase
    {
        protected readonly ILogger _logger;
        protected readonly AuthDbContext _authContext;

        protected AuthServiceBase(ILogger logger, AuthDbContext authContext)
        {
            _logger = logger;
            _authContext = authContext;
        }
    }
}
