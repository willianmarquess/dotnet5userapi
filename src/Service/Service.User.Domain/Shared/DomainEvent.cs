using MediatR;
using System;

namespace Service.Domain.Shared
{
    public abstract class DomainEvent : INotification
    {
        protected DomainEvent()
        {
            DateOccurred = DateTime.Now;
        }
        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.Now;
    }
}
