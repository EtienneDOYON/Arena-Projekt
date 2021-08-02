using AutoMapper;
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

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Route("testRoute")]
        [HttpGet]
        public IActionResult TestRoute()
        {
            return Ok();
        }
    }
}
