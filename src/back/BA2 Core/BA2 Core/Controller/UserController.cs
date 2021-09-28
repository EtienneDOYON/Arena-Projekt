using AutoMapper;
using Core.Services.Services.Interfaces;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BA2_Core.Controller
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            this.userService = userService;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("connectUser")]
        [HttpGet]
        public IActionResult ConnectUser([FromQuery]string Username, string Password)
        {
            return Ok(userService.DoesUserExist(Username, Password));
        }
    }
}
