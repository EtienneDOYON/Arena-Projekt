using Core.Identity.Data.Repository;
using Core.Identity.Models.Models;
using Core.Identity.Services.Classes;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Core.Services.Classes
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository applicationUserRepository;

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository)
        {
            this.applicationUserRepository = applicationUserRepository;
        }

        public ApplicationUser GetApplicationUserById(string id)
        {
            return applicationUserRepository.FindById(id);
        }

        public ApplicationUser GetApplicationUserByUsername(string username)
        {
            return applicationUserRepository.FindByUsername(username);
        }

        public string GetCurrentUserId(HttpContext HttpContext)
        {
            if (HttpContext.User.Identity.IsAuthenticated == false)
                return null;

            var userId = HttpContext.GetClaim("User_Id");
            if (userId == null)
                return null;

            var applicationUser = GetApplicationUserById(userId);
            if (applicationUser == null)
                return null;

            var email = HttpContext.GetClaim("User_Email");
            if (email != (applicationUser.Email ?? ""))
                return null;

            var securityStamp = HttpContext.GetClaim("AspNet.Identity.SecurityStamp");
            if (securityStamp != applicationUser.SecurityStamp)
                return null;

            return applicationUser.Id;
        }
    }
}
