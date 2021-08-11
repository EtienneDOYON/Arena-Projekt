using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Identity.Models.Enum
{
    public enum Level
    {
        None = 0,
        Root = 1,
        SuperAdmin = 2,
        Admin = 4,
        Orga = 8,
        Player = 16
    }
}
