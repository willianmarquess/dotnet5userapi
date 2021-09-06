using MediatR;
using Service.Domain.Users.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Users.EventHandlers
{
    public class UserDeletedEventHandler : INotificationHandler<UserDeletedEvent>
    {
        public Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
