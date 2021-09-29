using Core.Identity.Models.Enum;
using Core.Identity.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace Core.Identity.Data.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        protected DbSet<ApplicationUser> DbSet => Context?.Set<ApplicationUser>();

        protected ApplicationDbContext Context => new ApplicationDbContext();

        [InjectionMethod]
        public void Initialize()
        {
        }


        public ApplicationUser FindById(string id)
        {
            return DbSet.FirstOrDefault(x => x.EntityState == State.Active && x.Id == id);
        }

        public ApplicationUser FindByUsername(string username)
        {
            return DbSet.FirstOrDefault(x => x.EntityState == State.Active && x.UserName == username);
        }
    }
}
