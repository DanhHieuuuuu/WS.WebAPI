using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Order.ApplicationService.OrderManagerModule.Abstracts;
using WS.Order.Dtos.OrderManagerModule;
using WS.Shared.ApplicationService.Common;

namespace WS.WebAPI.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpPost("/Add-cart")]
        public IActionResult AddCart(AddCartDtos input)
        {
            try
            {
                return Ok(_orderService.AddCart(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/Delete-cart")]
        public IActionResult DeleteCart(int id)
        {
            try
            {
                _orderService.DeleteCart(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/Add-order")]
        public IActionResult AddOrder([FromQuery] int CartId)
        {
            try
            {
                return Ok(_orderService.AddOrderOrder(CartId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("/Add-Order-Detail")]
        public IActionResult AddOrderDetail([FromQuery] AddOrderDetailDtos input)
        {
            try
            {
                return Ok(_orderService.AddOrderDetai(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/Get-all-cart")]
        public IActionResult GetAllCart([FromQuery] FilterDtos input2)
        {
            try
            {
                return Ok(_orderService.GetAllCart(input2));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
