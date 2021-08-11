using Core.Identity.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Identity.Models.Models
{
    public class UserRole
    {
        [Required]
        public string Name { get; set; }
        public Level Level { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
