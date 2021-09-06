using Service.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Domain.Users.Events
{
    public class UserDeletedEvent : DomainEvent
    {
        public UserDeletedEvent(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
