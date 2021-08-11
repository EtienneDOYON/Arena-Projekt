using Core.Identity.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Identity.Controllers
{
    public class ApiControllerBase : ControllerBase
    {

        protected string GetUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

        protected ApplicationUser GetCurrentUser()
        {
            var userManager = (UserManager<ApplicationUser>)HttpContext.RequestServices.GetService(typeof(UserManager<ApplicationUser>));
            return userManager.GetUserAsync(User).Result;
        }

        protected void SaveChanges()
        {
            var context = (IdentityContext)HttpContext.RequestServices.GetService(typeof(IdentityContext));
            context.SaveChanges();
        }

    }
}
