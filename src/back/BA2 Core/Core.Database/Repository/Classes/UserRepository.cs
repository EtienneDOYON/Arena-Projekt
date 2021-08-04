using Core.Data.Entities;
using Core.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wave.Data.Ef6;

namespace Core.Data.Repository.Classes
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public bool IsUserValid(string Username, string Password)
        {
            return DbSet
                .Where(user => user.Username == Username && user.Password == Password && user.EntityState != HelperModels.State.Deleted)
                .Any();
        }
    }
}
