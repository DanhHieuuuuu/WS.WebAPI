using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WS.Product.ApplicationService.Common;
using WS.Product.ApplicationService.ProductManagerModule.Abstracts;
using WS.Product.Domain;
using WS.Product.Dtos.ProductManagerModule;
using WS.Product.Infrastructure;
using WS.Shared.ApplicationService.Common;
using WS.Shared.ApplicationService.User;

namespace WS.Product.ApplicationService.ProductManagerModule.Implements
{
    public class ProductService : ProductServiceBase, IProductService
    {
        private readonly IUserInforService _userInforService;
        public ProductService(ILogger<ProductService> logger, ProductDbContext productDbContext, IUserInforService userInforService) : base(logger, productDbContext)
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
            _productDbContext.ProdProducts.Add(product);
            _productDbContext.SaveChanges();
            return product;
        }
        public ProdProduct UpdateProduct([FromQuery] int id, CreateProductDtos input)
        {
            var product = _productDbContext.ProdProducts.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new Exception($"Không tìm thấy sản phẩm có Id là: {id}");
            }
            else 
            { 
                product.Name = input.Name;
                product.Quantity = input.Quantity;
                product.CreatedBy = input.CreatedBy;
               _productDbContext.SaveChanges();
                return product ;
            }
        }
        public string DeleteProduct(int id) 
        {
            var product = _productDbContext.ProdProducts.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return $"Không tìm thấy sản phẩm có Id là: {id}";
            }
            else
            {
                _productDbContext.ProdProducts.Remove(product);
                _productDbContext.SaveChanges();
                return "Đã xóa sản phẩm";
            }
        }
        public PageResultDtos<ProdProduct> GetAllProduct([FromQuery] FilterDtos input)
        {
            var result = new PageResultDtos<ProdProduct>();
            var query = _productDbContext.ProdProducts.Where(e =>
                        string.IsNullOrEmpty(input.KeyWord) ||
                        e.Name.ToLower().Contains(input.KeyWord.ToLower()));
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
