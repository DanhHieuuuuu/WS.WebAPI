using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Product.Domain;
using WS.Shared.ApplicationService.Common;

namespace WS.Shared.ApplicationService.Product
{
    public interface IProductInfService
    {
        ProdProduct GetByIdProduct( int id);
    }
}
