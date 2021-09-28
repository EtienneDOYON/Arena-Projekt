using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Identity.Models.Helpers
{
    public interface IEntity<T> : IEntity
    {
        public T Id { get; set; }
    }

    public interface IEntity
    {

    }
}
