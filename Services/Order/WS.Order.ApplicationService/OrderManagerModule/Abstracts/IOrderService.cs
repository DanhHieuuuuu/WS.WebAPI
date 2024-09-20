using Microsoft.AspNetCore.Mvc;
using WS.Order.Domain;
using WS.Order.Dtos.OrderManagerModule;
using WS.Shared.ApplicationService.Common;

namespace WS.Order.ApplicationService.OrderManagerModule.Abstracts
{
    public interface IOrderService
    {
        OrderCart AddCart(AddCartDtos input);
        OrderOrderDtos AddOrderOrder([FromQuery] int CartId);
        OrderDetailDtos AddOrderDetai([FromQuery] AddOrderDetailDtos input);
        void DeleteCart([FromQuery] int Id);
        PageResultDtos<OrderCart> GetAllCart([FromQuery] FilterDtos input);
    }
}
