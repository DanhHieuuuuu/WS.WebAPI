using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Product.ApplicationService.Common;
using WS.Product.Domain;
using WS.Shared.ApplicationService.Common;
using WS.Product.Infrastructure;
using WS.Shared.ApplicationService.Product;

namespace WS.Product.ApplicationService.ProductManagerModule.Implements
{
    public class ProductInfService : ProductServiceBase, IProductInfService
    {
        public ProductInfService(ILogger<ProductInfService> logger, ProductDbContext productDbContext ) : base(logger, productDbContext)
        {
        }
        public ProdProduct GetByIdProduct( int id)
        {
            var product = _productDbContext.ProdProducts.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new Exception($"Không tìm thấy sản phẩm có Id là: {id}");
            }
            else
            {
                return product;
            }
        }
    }
}
