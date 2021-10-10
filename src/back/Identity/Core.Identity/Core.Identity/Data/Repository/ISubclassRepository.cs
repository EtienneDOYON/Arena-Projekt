using Core.Identity.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Identity.Data.Repository
{
    public interface ISubclassRepository : IRepository<Subclass, int>
    {
        public Subclass GetSubclassById(int id);
            
        public Subclass GetSubclassByWarrior(Warrior warrior);

        public Subclass GetSubclassByWarriorId(int warriorId);

        public Subclass GetSubclassByName(string name);

        public List<Subclass> GetAllSubclassesByClassId(int id);

        public List<Subclass> GetAllSubclasses();
    }
}
