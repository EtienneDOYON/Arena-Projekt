using Core.Identity.Models.Models;
using Core.Identity.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Identity.Services.Interfaces
{
    public interface IClassService
    {
        public bool CreateClass(ClassViewModel classViewModel);

        public bool UpdateClass(ClassViewModel classViewModel);

        public bool DeleteClass(int classId);

        public List<Class> GetAllClasses();

        public Class GetClassById(int id);

        public Class GetClassByName(string name);
    }
}
