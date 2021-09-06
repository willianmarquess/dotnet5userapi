using Service.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Domain.Users.Events
{
    public class UserCreatedEvent : DomainEvent
    {
        public UserCreatedEvent(string id, string email, string password, string type)
        {
            Id = id;
            Email = email;
            Password = password;
            Type = type;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}
