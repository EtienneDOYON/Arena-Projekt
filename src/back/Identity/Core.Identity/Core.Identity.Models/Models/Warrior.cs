using Core.Identity.Models.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Identity.Models.Models
{
    public class Warrior : Entity<int>
    {
        // La race du gladiateur
        [ForeignKey("Class")]
        public int Class_Id { get; set; }
        public Class Class { get; set; }

        // La culture du gladiateur
        [ForeignKey("Subclass")]
        public int Subclass_Id { get; set; }
        public Subclass Subclass { get; set; }

        public uint TotalXp { get; set; }
        public uint TrainedXp { get; set; }

        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
