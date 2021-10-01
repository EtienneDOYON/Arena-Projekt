using Core.Identity.Models.Models;
using Core.Identity.Services.Classes;
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
    [Route("warriors")]
    public class WarriorController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IApplicationUserService applicationUserService;
        private readonly AuthenticatorTokenProvider<ApplicationUser> authenticatorTokenProvider;
        private readonly IConfiguration configuration;

        public WarriorController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IApplicationUserService applicationUserService, AuthenticatorTokenProvider<ApplicationUser> authenticatorTokenProvider,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.applicationUserService = applicationUserService;
            this.authenticatorTokenProvider = authenticatorTokenProvider;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllWarriors()
        {
            var test = HttpContext.GetClaim("User_Id");
            return Ok();
        }
    }
}
