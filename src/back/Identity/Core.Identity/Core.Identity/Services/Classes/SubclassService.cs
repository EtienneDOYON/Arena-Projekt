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
    public class SubclassService : ISubclassService
    {
        private readonly ISubclassRepository subclassRepository;
        private readonly IClassRepository classRepository;

        public SubclassService(ISubclassRepository subclassRepository, IClassRepository classRepository)
        {
            this.subclassRepository = subclassRepository;
            this.classRepository = classRepository;
        }

        public bool CreateSubclass(SubclassViewModel subclassViewModel)
        {
            var subclass = subclassRepository.GetSubclassByName(subclassViewModel.Name);
            if (subclass != null)
                return false;

            var _class = classRepository.GetClassById(subclassViewModel.ClassId);
            if (_class == null)
                return false;

            subclass = new Subclass();
            subclass.Name = subclassViewModel.Name;
            subclass.Class_Id = subclassViewModel.ClassId;

            subclassRepository.Insert(subclass);
            subclassRepository.SaveChanges();
            return true;
        }

        public bool UpdateSubclass(SubclassViewModel subclassViewModel)
        {
            var _subclass = subclassRepository.GetSubclassById(subclassViewModel.Id);
            if (_subclass == null)
                return false;

            var subclass = subclassRepository.GetSubclassByName(subclassViewModel.Name);
            if (subclass != null)
                return false;

            var _class = classRepository.GetClassById(subclassViewModel.ClassId);
            if (_class == null)
                return false;

            _subclass.Name = subclassViewModel.Name;
            _subclass.Class_Id = subclassViewModel.ClassId;

            subclassRepository.Update(_subclass);
            subclassRepository.SaveChanges();
            return true;
        }

        public bool DeleteSubclass(int subclassId)
        {
            var _subclass = subclassRepository.GetSubclassById(subclassId);
            if (_subclass == null || _subclass.EntityState == Models.Enum.State.Deleted)
                return true;

            subclassRepository.DeleteEntity(_subclass);
            subclassRepository.SaveChanges();
            return true;
        }

        public List<Subclass> GetAllSubclasses()
        {
            return subclassRepository.GetAllSubclasses();
        }

        public List<Subclass> GetAllSubclassesOfClass(int classId)
        {
            return subclassRepository.GetAllSubclassesByClassId(classId);
        }

        public Subclass GetSubclassById(int subclassId)
        {
            return subclassRepository.GetSubclassById(subclassId);
        }

        public Subclass GetSubclassByName(string subclassName)
        {
            return subclassRepository.GetSubclassByName(subclassName);
        }
    }
}
