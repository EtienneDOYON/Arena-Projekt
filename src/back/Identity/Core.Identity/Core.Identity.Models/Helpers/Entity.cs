using Core.Identity.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Identity.Models.Helpers
{
    public class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
        public State EntityState { get; set; }
    }
}
