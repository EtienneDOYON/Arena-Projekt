using Core.Identity.Data.Repository;
using Core.Identity.Models.Models;
using Core.Identity.Models.Models.ViewModels;
using Core.Identity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Identity.Services.Classes
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository classRepository;
        private readonly ISubclassRepository subclassRepository;

        public ClassService(IClassRepository classRepository, ISubclassRepository subclassRepository)
        {
            this.classRepository = classRepository;
            this.subclassRepository = subclassRepository;
        }

        public bool CreateClass(SubclassViewModel classViewModel)
        {
            var _class = classRepository.GetClassByName(classViewModel.Name);
            if (_class != null)
                return false;

            _class.Name = classViewModel.Name;

            classRepository.Update(_class);
            classRepository.SaveChanges();
            return true;
        }

        public bool UpdateClass(SubclassViewModel classViewModel)
        {
            var _class = classRepository.GetClassById(classViewModel.Id);
            if (_class == null)
                return false;

            var classWithName = classRepository.GetClassByName(classViewModel.Name);
            if (classWithName != null && classWithName.Id != classViewModel.Id)
                return false;

            _class.Name = classViewModel.Name;

            classRepository.Update(_class);
            classRepository.SaveChanges();

            return true;
        }

        public bool DeleteClass(int classId)
        {
            var _class = classRepository.GetClassById(classId);
            if (_class == null || _class.EntityState == Models.Enum.State.Deleted)
                return true;

            var subclassList = subclassRepository.GetAllSubclassesByClassId(classId);
            if (subclassList.Count > 0)
                return false;

            classRepository.DeleteEntity(_class);
            classRepository.SaveChanges();

            return true;
        }

        public List<Class> GetAllClasses()
        {
            return classRepository.GetAllClasses();
        }

        public Class GetClassById(int id)
        {
            return classRepository.GetClassById(id);
        }

        public Class GetClassByName(string name)
        {
            return classRepository.GetClassByName(name);
        }
    }
}
