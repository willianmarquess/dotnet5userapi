using Service.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Domain.Users.Entities
{
    public class User : Entity
    {
        public User(string email, string password, string type)
        {
            Email = email;
            Password = password;
            Type = type;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}
