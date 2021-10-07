using Core.Identity.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Identity.Models.Models
{
    public class Warrior : Entity<int>
    {
        // La race du gladiateur
        public int Class_Id { get; set; }

        // La culture du gladiateur
        public int Subclass_Id { get; set; }

        public uint TotalXp { get; set; }
        public uint TrainedXp { get; set; }

        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public string UserId { get; set; }
    }
}
