using Core.Identity.Data.Repository;
using Core.Identity.Models.Models;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
