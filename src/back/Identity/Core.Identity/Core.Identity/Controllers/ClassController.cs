using Core.Identity.Models.Models;
using Core.Identity.Models.Models.ViewModels;
using Core.Identity.Services.Classes;
using Core.Identity.Services.Interfaces;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Identity.Controllers
{
    [ApiController]
    [Route("class")]
    public class ClassController : ControllerBase
    {
        private readonly IApplicationUserService applicationUserService;
        private readonly IClassService classService;

        public ClassController(IApplicationUserService applicationUserService, IClassService classService)
        {
            this.applicationUserService = applicationUserService;
            this.classService = classService;
        }

        [HttpGet]
        [Authorize("GodsGame")]
        public async Task<ActionResult<List<Class>>> GetAllClasses()
        {
            var userId = applicationUserService.GetCurrentUserId(HttpContext);

            if (userId == null)
                return BadRequest("You need to be logged in to perform this action");

            return Ok(classService.GetAllClasses());
        }

        [HttpGet("/{id}")]
        [Authorize("GodsGame")]
        public async Task<ActionResult<Class>> GetClass([FromRoute] int id)
        {
            var userId = applicationUserService.GetCurrentUserId(HttpContext);

            if (userId == null)
                return BadRequest("You need to be logged in to perform this action");

            return Ok(classService.GetClassById(id));
        }

        [HttpPost]
        [Authorize("GodsGame")]
        public async Task<ActionResult> CreateClass([FromBody] ClassViewModel classViewModel)
        {
            var userId = applicationUserService.GetCurrentUserId(HttpContext);

            // TODO : Check Admin permissions
            if (userId == null)
                return BadRequest("You need to be logged in to perform this action");

            if (classViewModel.Name == null)
                return BadRequest("No name specified");

            var ret = classService.CreateClass(classViewModel);

            if (!ret)
                return BadRequest("A class with this name already exists !");

            return Ok();
        }

        [HttpPut]
        [Authorize("GodsGame")]
        public async Task<ActionResult> UpdateClass([FromBody] ClassViewModel classViewModel)
        {
            var userId = applicationUserService.GetCurrentUserId(HttpContext);

            // TODO : Check Admin permissions
            if (userId == null)
                return BadRequest("You need to be logged in to perform this action");

            var ret = classService.UpdateClass(classViewModel);

            if (!ret)
                return BadRequest("A class with this name already exists !");

            return Ok();
        }

        [HttpDelete("/{id}")]
        [Authorize("GodsGame")]
        public async Task<ActionResult> DeleteClass([FromRoute] int classId)
        {
            var userId = applicationUserService.GetCurrentUserId(HttpContext);

            // TODO : Check Admin permissions
            if (userId == null)
                return BadRequest("You need to be logged in to perform this action");

            var ret = classService.DeleteClass(classId);

            if (!ret)
                return BadRequest("Cannot delete a class with subclasses. Please delete the subclasses first.");

            return Ok();
        }
    }
}
