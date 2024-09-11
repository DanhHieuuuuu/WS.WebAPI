using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Auth.ApplicationService.UserModule.Abstracts;

namespace WS.WebAPI.Controllers.Auth
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }
    }
}
