using Core.Identity.Models.Models;
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
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IApplicationUserService applicationUserService;
        private readonly IConfiguration configuration;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IApplicationUserService applicationUserService,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.applicationUserService = applicationUserService;
            this.configuration = configuration;
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

            var applicationUser = applicationUserService.GetApplicationUserByUsername(user.Username);

            if (applicationUser == null)
                return BadRequest("InvalidUsernameOrPassword");

            var signInResult = await signInManager.CheckPasswordSignInAsync(applicationUser, user.Password, false);
            if (!signInResult.Succeeded)
                return BadRequest("InvalidUsernameOrPassword");

            var claims = GetClaimsForUser(applicationUser);
            var duration = TimeSpan.FromMinutes(2);
            var token = CreateAccessToken(claims, duration);

            await signInManager.SignInWithClaimsAsync(applicationUser, new AuthenticationProperties(), User.Claims);

            var result = new Dictionary<string, object>();
            result["access_token"] = token;
            result["userName"] = applicationUser.UserName;
            result[".expires"] = (DateTime.UtcNow + duration).ToString("R");
            result[".issued"] = DateTime.UtcNow.ToString("R");
            result["expires_in"] = duration.TotalSeconds;
            result["token_type"] = "bearer";

            Response.Headers["Expires"] = (-1).ToString();

            return Ok(result);
        }

        private List<Claim> GetClaimsForUser(ApplicationUser user)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim("User_Id", user.Id));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim("User_Email", user.Email ?? string.Empty));
            claims.Add(new Claim("AspNet.Identity.SecurityStamp", user.SecurityStamp));

            return claims;
        }

        private string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan expiration)
        {
            var now = DateTime.UtcNow;
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: configuration["JwtTokenLogin:Issuer"],
                audience: configuration["JwtTokenLogin:Audience"],
                claims: claims,
                notBefore: now,
                expires: now.Add(expiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtTokenLogin:Secret"])), SecurityAlgorithms.HmacSha256, SecurityAlgorithms.Sha256Digest)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
