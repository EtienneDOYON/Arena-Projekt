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
    [Route("subclass")]
    public class SubclassController : ControllerBase
    {
        private readonly IApplicationUserService applicationUserService;
        private readonly IClassService classService;
        private readonly ISubclassService subclassService;

        public SubclassController(IApplicationUserService applicationUserService, IClassService classService, ISubclassService subclassService)
        {
            this.applicationUserService = applicationUserService;
            this.classService = classService;
            this.subclassService = subclassService;
        }

        [HttpGet]
        [Authorize("GodsGame")]
        public async Task<ActionResult<List<Class>>> GetAllSubclasses()
        {
            var userId = applicationUserService.GetCurrentUserId(HttpContext);

            if (userId == null)
                return BadRequest("You need to be logged in to perform this action");

            return Ok(subclassService.GetAllSubclasses());
        }

        [HttpGet("GetAllSubclassesOfClass/{id}")]
        [Authorize("GodsGame")]
        public async Task<ActionResult<List<Class>>> GetAllSubclassesOfClass([FromRoute] int id)
        {
            var userId = applicationUserService.GetCurrentUserId(HttpContext);

            if (userId == null)
                return BadRequest("You need to be logged in to perform this action");

            return Ok(subclassService.GetAllSubclassesOfClass(id));
        }

        [HttpGet("/{id}")]
        [Authorize("GodsGame")]
        public async Task<ActionResult<Class>> GetClass([FromRoute] int id)
        {
            var userId = applicationUserService.GetCurrentUserId(HttpContext);

            if (userId == null)
                return BadRequest("You need to be logged in to perform this action");

            return Ok(subclassService.GetSubclassById(id));
        }

        [HttpPost]
        [Authorize("GodsGame")]
        public async Task<ActionResult> CreateClass([FromBody] SubclassViewModel subclassViewModel)
        {
            var userId = applicationUserService.GetCurrentUserId(HttpContext);

            // TODO : Check Admin permissions
            if (userId == null)
                return BadRequest("You need to be logged in to perform this action");

            var ret = subclassService.CreateSubclass(subclassViewModel);

            if (!ret)
                return BadRequest("A class with this name already exists !");

            return Ok();
        }

        [HttpPut]
        [Authorize("GodsGame")]
        public async Task<ActionResult> UpdateClass([FromBody] SubclassViewModel subclassViewModel)
        {
            var userId = applicationUserService.GetCurrentUserId(HttpContext);

            // TODO : Check Admin permissions
            if (userId == null)
                return BadRequest("You need to be logged in to perform this action");

            var ret = subclassService.UpdateSubclass(subclassViewModel);

            if (!ret)
                return BadRequest("A class with this name already exists !");

            return Ok();
        }

        [HttpDelete("/{id}")]
        [Authorize("GodsGame")]
        public async Task<ActionResult> DeleteClass([FromRoute] int subclassId)
        {
            var userId = applicationUserService.GetCurrentUserId(HttpContext);

            // TODO : Check Admin permissions
            if (userId == null)
                return BadRequest("You need to be logged in to perform this action");

            var ret = subclassService.DeleteSubclass(subclassId);

            if (!ret)
                return BadRequest("Cannot delete a class with subclasses. Please delete the subclasses first.");

            return Ok();
        }
    }
}
