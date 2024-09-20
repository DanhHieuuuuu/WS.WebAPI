using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Product.Domain;
using WS.Product.Dtos.ProductManagerModule;
using WS.Shared.ApplicationService.Common;

namespace WS.Product.ApplicationService.ProductManagerModule.Abstracts
{
    public interface IProductService
    {
        ProdProduct CreateProduct(CreateProductDtos input);
        string DeleteProduct(int id);
        PageResultDtos<ProdProduct> GetAllProduct([FromQuery] FilterDtos input);
        ProdProduct GetByIdProduct([FromQuery] int id);
        ProdProduct UpdateProduct([FromQuery] int i, CreateProductDtos input);
    }
}
