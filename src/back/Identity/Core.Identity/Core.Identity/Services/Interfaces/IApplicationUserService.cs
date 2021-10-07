using Core.Identity.Models.Models;
using Microsoft.AspNetCore.Http;

namespace Core.Services.Interfaces
{
    public interface IApplicationUserService
    {
        ApplicationUser GetApplicationUserById(string id);
        ApplicationUser GetApplicationUserByUsername(string username);

        public string GetCurrentUserId(HttpContext HttpContext);
    }
}
