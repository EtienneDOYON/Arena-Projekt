using Core.Identity.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Identity.Data.Repository
{
    public class SubclassRepository : Repository<Subclass, int>, ISubclassRepository
    {
        public List<Subclass> GetAllSubclassesByClassId(int id)
        {
            return DbSet.Where(x => x.Class_Id == id).ToList();
        }

        public Subclass GetSubclassById(int id)
        {
            return DbSet.FirstOrDefault(c => c.Id == id);
        }

        public Subclass GetSubclassByName(string name)
        {
            return DbSet.FirstOrDefault(x => x.Name == name);
        }

        public Subclass GetSubclassByWarrior(Warrior warrior)
        {
            return DbSet.FirstOrDefault(c => c.Id == warrior.Subclass_Id);
        }

        public Subclass GetSubclassByWarriorId(int warriorId)
        {
            Warrior warrior = Context.Warriors.FirstOrDefault(w => w.Id == warriorId);
            if (warrior == null) return null;

            return GetSubclassByWarrior(warrior);
        }

        public List<Subclass> GetAllSubclasses()
        {
            return DbSet.Where(x => x.EntityState == Models.Enum.State.Active).ToList();
        }
    }
}
