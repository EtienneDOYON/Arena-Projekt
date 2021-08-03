using AutoMapper;
using Core.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA2_Core.Controller
{
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

        [Route("userExists")]
        [HttpGet]
        public IActionResult UserExists([FromQuery]string Username, string Password)
        {
            return Ok(userService.DoesUserExist(Username, Password));
        }
    }
}
