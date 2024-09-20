using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WS.Order.ApplicationService.Common;
using WS.Order.ApplicationService.OrderManagerModule.Abstracts;
using WS.Order.Domain;
using WS.Order.Dtos.OrderManagerModule;
using WS.Order.Infrastructure;
using WS.Product.Domain;
using WS.Product.Infrastructure;
using WS.Shared.ApplicationService.Common;
using WS.Shared.ApplicationService.Product;
using WS.Shared.ApplicationService.UserException;

// sage patten
// CSh
namespace WS.Order.ApplicationService.OrderManagerModule.Implements
{
    public class OrderService : OrderServiceBase, IOrderService
    {
        private IProductInfService _productInfService;

        public OrderService(
            ILogger<OrderService> logger,
            OrderDbContext orderDbContext,
            IProductInfService productInfService
        )
            : base(logger, orderDbContext)
        {
            _productInfService = productInfService;
        }

        public OrderCart AddCart(AddCartDtos input)
        {
            var product = _productInfService.GetByIdProduct(input.ProductId);
            if (product == null)
            {
                throw new UserExceptions("Không tồn tại sản phẩm");
            }
            var cart = new OrderCart
            {
                ProductId = input.ProductId,
                Quantity = input.Quantity,
                UserId = input.UserId,
            };
            _orderDbContext.OrderCarts.Add(cart);
            _orderDbContext.SaveChanges();
            return cart;
        }

        public void DeleteCart([FromQuery] int Id)
        {
            var findCart = _orderDbContext.OrderCarts.FirstOrDefault(x => x.Id == Id);
            if (findCart == null)
            {
                throw new UserExceptions($"Không tồn tại giỏ hàng có Id là: {Id}");
            }
            _orderDbContext.OrderCarts.Remove(findCart);
            _orderDbContext.SaveChanges();
            throw new UserExceptions("Đã xóa thành công");
        }

        public OrderOrderDtos AddOrderOrder([FromQuery] int CartId)
        {
            var cart = _orderDbContext.OrderCarts.FirstOrDefault(c => c.Id == CartId);
            if (cart == null)
            {
                throw new UserExceptions("Không tồn tại trong giỏ hàng");
            }
            var newOrder = new OrderOrder
            {
                CreateDate = DateTime.Now,
                Status = true,
                UserId = cart.UserId,
                ProductId = cart.ProductId,
                Quantiy = cart.Quantity,
            };
            _orderDbContext.OrderOrders.Add(newOrder);
            _orderDbContext.SaveChanges();
            var result = new OrderOrderDtos
            {
                CreateDate = DateTime.Now,
                Status = true,
                UserId = cart.UserId,
                ProductId = cart.ProductId,
                Quantiy = cart.Quantity,
            };
            return result;
        }

        public OrderDetailDtos AddOrderDetai([FromQuery] AddOrderDetailDtos input)
        {
            var findOrder = _orderDbContext.OrderOrders.FirstOrDefault(o => o.Id == input.OrderId);
            if (findOrder == null)
            {
                throw new UserExceptions($"Không tìm thấy Order có id: {input.OrderId}");
            }
            var newOrderDetail = new OrderDetail
            {
                OrderId = input.OrderId,
                ProductId = findOrder.ProductId,
                Quantity = findOrder.Quantiy,
                UnitPrice = input.UnitPrice,
            };
            _orderDbContext.OrderDetails.Add(newOrderDetail);
            _orderDbContext.SaveChanges();
            var restult = new OrderDetailDtos
            {
                OrderId = input.OrderId,
                ProductId = findOrder.ProductId,
                Quantity = findOrder.Quantiy,
                UnitPrice = input.UnitPrice,
            };
            return restult;
        }

        public PageResultDtos<OrderCart> GetAllCart([FromQuery] FilterDtos input)
        {
            var result = new PageResultDtos<OrderCart>();
            var query = _orderDbContext.OrderCarts.Where(e =>
                string.IsNullOrEmpty(input.KeyWord)
                || e.Id.ToString().ToLower().Contains(input.KeyWord.ToLower())
            );
            query = query
                .OrderByDescending(e => e.Quantity)
                .ThenByDescending(e => e.ProductId)
                .Skip(input.Skip())
                .Take(input.PageSize);

            result.Items = query.ToList();

            return result;
        }
    }
}
