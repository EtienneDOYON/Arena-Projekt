using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Wave.Data.Repositories;

namespace Core.Data.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public bool IsUserValid(string Username, string Password);
    }
}
