using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Product.ApplicationService.Common;
using WS.Product.ApplicationService.ProductManagerModule.Abstracts;
using WS.Product.Domain;
using WS.Product.Dtos.ProductManagerModule;
using WS.Product.Dtos.ProductManagerModule.Common;
using WS.Product.Infrastructure;
using WS.Shared.ApplicationService.User;

namespace WS.Product.ApplicationService.ProductManagerModule.Implements
{
    public class ProductService : ProductServiceBase, IProductService
    {
        private IUserInforService _userInforService;
        public ProductService(ILogger<ProductService> logger, ProductDbContext dbContext, IUserInforService userInforService ) : base(logger, dbContext) 
        { 
            _userInforService = userInforService;
        }
        
        public ProdProduct CreateProduct(CreateProductDtos input)
        {
            var product = new ProdProduct
            {
                Name = input.Name,
                Quantity = input.Quantity,
                CreatedBy = input.CreatedBy,
            };
            _dbContext.ProdProducts.Add(product);
            _dbContext.SaveChanges();
            return product;

        }

        public ProdProduct UpdateProduct([FromQuery] int id, CreateProductDtos input)
        {
            var product = _dbContext.ProdProducts.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new Exception($"Không tìm thấy sản phẩm có Id là: {id}");
            }
            else 
            { 
                product.Name = input.Name;
                product.Quantity = input.Quantity;
                product.CreatedBy = input.CreatedBy;
               _dbContext.SaveChanges();
                return product ;
            }
        }
        public void DeleteProduct(int id) 
        {
            var product = _dbContext.ProdProducts.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new Exception($"Không tìm thấy sản phẩm có Id là: {id}");
            }
            else
            {
                _dbContext.ProdProducts.Remove(product);
                _dbContext.SaveChanges();
                throw new Exception("Đã xóa sản phẩm");
            }
        }
        public PageResultDtos<ProdProduct> GetAll([FromQuery] FilterDtos input)
        {
            var result = new PageResultDtos<ProdProduct>();

            var query = _dbContext.ProdProducts.Where(e =>
                        string.IsNullOrEmpty(input.KeyWord) ||
                        e.Name.ToLower().Contains(input.KeyWord.ToLower()));
            result.TotalItem = query.Count();

            query = query
                    .OrderByDescending(e => e.Name)
                    .ThenByDescending(e => e.CreatedBy)
                    .Skip(input.Skip())
                    .Take(input.PageSize);

            result.Items = query.ToList();

            return result;

        }
        public ProdProduct GetByIdProduct([FromQuery] int id)
        {
            var product = _dbContext.ProdProducts.FirstOrDefault(x => x.Id == id);
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
