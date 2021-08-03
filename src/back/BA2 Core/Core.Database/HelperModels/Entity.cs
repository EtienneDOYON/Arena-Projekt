using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data.HelperModels
{
    public class Entity : IEntity
    {
        public int Id { get; set; }

        public string ModifiedBy { get; set; }

        public State EntityState { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModificationDate { get; set; } = DateTime.UtcNow;

    }

    public interface IEntity
    {
        int Id { get; set; }

        string ModifiedBy { get; set; }

        DateTime CreationDate { get; set; }
        DateTime LastModificationDate { get; set; }
    }
}
