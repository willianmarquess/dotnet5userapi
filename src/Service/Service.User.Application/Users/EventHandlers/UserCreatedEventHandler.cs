using MediatR;
using Service.Domain.Users.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Users.EventHandlers
{
    public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
