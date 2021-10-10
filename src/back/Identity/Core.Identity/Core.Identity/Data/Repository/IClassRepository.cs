using Core.Identity.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Identity.Data.Repository
{
    public interface IClassRepository : IRepository<Class, int>
    {
        public Class GetClassById(int id);
            
        public Class GetClassByWarrior(Warrior warrior);

        public Class GetClassByWarriorId(int warriorId);

        public Class GetClassByName(string name);

        public List<Class> GetAllClasses();
    }
}
