using Core.Identity.Models.Enum;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Identity.Models.Models
{
    public class ApplicationUser
    {
        public int RoleId { get; set; }

        [ForeignKey(nameof RoleId)]
        public virtual UserRole Role { get; set; }

        public string Username { get; set; }

        public Language Language { get; set; }

        public bool IsLocked { get; set; }
        public DateTimeOffset? DateLockEnd { get; set; }

        public bool FirstLogin { get; set; }
        
        
        // Audit data
        public DateTime CreationTime { get; set; }

        public DateTime? LastEditionTime { get; set; }


        public virtual ICollection<IdentityUserClaim<string>> Claims { get; } = new List<IdentityUserClaim<string>>();
    }
}
