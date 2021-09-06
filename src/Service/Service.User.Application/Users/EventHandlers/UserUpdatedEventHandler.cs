using MediatR;
using Service.Domain.Users.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Users.EventHandlers
{
    public class UserUpdatedEventHandler : INotificationHandler<UserUpdatedEvent>
    {
        public Task Handle(UserUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
