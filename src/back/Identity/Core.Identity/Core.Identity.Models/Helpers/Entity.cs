using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Identity.Models.Helpers
{
    public class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}
