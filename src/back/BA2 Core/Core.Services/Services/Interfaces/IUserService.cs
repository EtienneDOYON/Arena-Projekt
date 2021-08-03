using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Services.Interfaces
{
    public interface IUserService
    {
        public bool DoesUserExist(string username, string password);
    }
}
