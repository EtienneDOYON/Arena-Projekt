using Core.Identity.Models.Models;
using Core.Identity.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Identity.Services.Interfaces
{
    public interface ISubclassService
    {
        public bool CreateSubclass(SubclassViewModel subclassViewModel);

        public bool UpdateSubclass(SubclassViewModel classViewModel);

        public bool DeleteSubclass(int classId);

        public List<Subclass> GetAllSubclasses();

        public List<Subclass> GetAllSubclassesOfClass(int classId);

        public Subclass GetSubclassById(int subclassId);

        public Subclass GetSubclassByName(string subclassName);
    }
}
