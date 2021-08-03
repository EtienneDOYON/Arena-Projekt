using Core.Data.HelperModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
