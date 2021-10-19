using System;
using System.Collections.Generic;
using System.Text;

namespace Hyperativa.Business.Models
{
    public class User : Entity
    {    
        public string Username { get; set; }
        public string Password { get; set; }
        public string Access { get; set; }
    }
}
