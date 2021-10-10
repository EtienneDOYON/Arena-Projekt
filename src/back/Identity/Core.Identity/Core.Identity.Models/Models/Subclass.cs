using Core.Identity.Models.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Identity.Models.Models
{
    public class Subclass : Entity<int>
    {
        public string Name { get; set; }

        [ForeignKey("Class")]
        public int Class_Id { get; set; }
        public Class Class { get; set; }
    }
}
