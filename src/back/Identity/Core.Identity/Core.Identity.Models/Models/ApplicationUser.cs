using Core.Identity.Models.Enum;
using Core.Identity.Models.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Identity.Models.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public State EntityState { get; set; }



        /*        public int RoleId { get; set; }

                [ForeignKey("RoleId")]
                public virtual UserRole Role { get; set; }

                public Language Language { get; set; }

                public bool IsLocked { get; set; }
                public DateTimeOffset? DateLockEnd { get; set; }

                public bool FirstLogin { get; set; }


                // Audit data
                public DateTime CreationTime { get; set; }

                public DateTime? LastEditionTime { get; set; }*/


        public virtual ICollection<IdentityUserClaim<string>> Claims { get; } = new List<IdentityUserClaim<string>>();
    }
}
