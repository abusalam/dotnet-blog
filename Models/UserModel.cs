using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI8.Models
{
    public class UserModel
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public bool? IsActive { get; set; }
    }
}