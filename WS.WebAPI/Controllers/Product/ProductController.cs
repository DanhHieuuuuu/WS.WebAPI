using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Product.ApplicationService.ProductManagerModule.Abstracts;
using WS.Product.Dtos.ProductManagerModule;
using WS.Shared.ApplicationService.Common;

namespace WS.WebAPI.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) 
        { 
            _productService = productService;
        }
        [HttpPost("/Create-Product")]
        public IActionResult CreateProduct(CreateProductDtos input)
        {
            try
            {
                return Ok(_productService.CreateProduct(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/Update-Product")]
        public IActionResult UpdateProduct([FromQuery]int id, CreateProductDtos input2)
        {
                try
                {
                    return Ok(_productService.UpdateProduct(id, input2));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
        }
        [HttpDelete("/Delete-Product")]
        public IActionResult DeleteProduct([FromQuery] int id) 
        {
            try
            {
                
                return Ok(_productService.DeleteProduct(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/Get-All-2")]
        public IActionResult GetAllProduct2([FromQuery] FilterDtos input4)
        {
            try
            {
                return Ok(_productService.GetAllProduct(input4));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/Get-By-Id")]
        public IActionResult GetIdProduct([FromQuery] int id) 
        {
            try
            {
                return Ok(_productService.GetByIdProduct(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
