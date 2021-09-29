using Core.Identity.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Identity.Data.Repository
{
    public interface IApplicationUserRepository
    {
        ApplicationUser FindById(string id);
        ApplicationUser FindByUsername(string username);
    }
}
