using Core.Identity.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Identity.Controllers
{
    [ApiController]
    [Route("auth")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody]UserViewModel user)
        {
            if (user.Password == null || user.Username == null)
                return BadRequest("InvalidUsernameOrPassword");

            var applicationUser = new ApplicationUser();
            applicationUser.UserName = user.Username;

            var createUserResult = await userManager.CreateAsync(applicationUser, user.Password);
            if (!createUserResult.Succeeded)
                return BadRequest(createUserResult.Errors.First().Code);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody]UserViewModel user)
        {
            if (user.Password == null || user.Username == null)
                return BadRequest("InvalidUsernameOrPassword");

            var applicationUser = new ApplicationUser(); // TODO : Get the ApplicationUser from the DB => Create a Service and everything

            var signInResult = await signInManager.CheckPasswordSignInAsync(applicationUser, user.Password, false);
            if (!signInResult.Succeeded)
                return BadRequest("InvalidUsernameOrPassword");

            return Ok();
        }
    }
}
