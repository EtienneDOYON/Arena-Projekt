using Core.Identity.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IApplicationUserService
    {
        ApplicationUser GetApplicationUserById(string id);
        ApplicationUser GetApplicationUserByUsername(string username);
    }
}
