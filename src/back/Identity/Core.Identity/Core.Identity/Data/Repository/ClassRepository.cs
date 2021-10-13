using Core.Identity.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Identity.Data.Repository
{
    public class ClassRepository : Repository<Class, int>, IClassRepository
    {
        public Class GetClassById(int id)
        {
            return DbSet.FirstOrDefault(c => c.Id == id);
        }

        public Class GetClassByWarrior(Warrior warrior)
        {
            return DbSet.FirstOrDefault(c => c.Id == warrior.Class_Id);
        }

        public Class GetClassByWarriorId(int warriorId)
        {
            Warrior warrior = Context.Warriors.FirstOrDefault(w => w.Id == warriorId);
            if (warrior == null) return null;

            return GetClassByWarrior(warrior);
        }

        public Class GetClassByName(string name)
        {
            return DbSet.FirstOrDefault(x => x.Name == name && x.EntityState == Models.Enum.State.Active);
        }

        public List<Class> GetAllClasses()
        {
            return DbSet.Where(x => x.EntityState == Models.Enum.State.Active).ToList();
        }
    }
}
