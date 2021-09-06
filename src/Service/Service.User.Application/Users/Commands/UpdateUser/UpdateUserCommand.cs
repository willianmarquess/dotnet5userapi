using MediatR;
using Raven.Client.Documents.Session;
using Service.Domain.Users.Entities;
using Service.Domain.Users.Events;
using Service.Infra.Users;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<User>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IAsyncDocumentSession _session;
        private readonly IMediator _mediatr;

        public UpdateUserCommandHandler(UserContext userContext, IMediator mediatr)
        {
            _session = userContext.DocumentStore.OpenAsyncSession();
            _mediatr = mediatr;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _session.LoadAsync<User>(request.Id, cancellationToken);
            user.Email = request.Email;
            user.Type = request.Type;
            user.Password = request.Password;
            user.LastModified = DateTime.Now;
            user.LastModifiedBy = "admin@admin.com";
            await _session.SaveChangesAsync(cancellationToken);

            await _mediatr.Publish(new UserUpdatedEvent(user.Id, user.Email, user.Password, user.Type), cancellationToken);

            return user;
        }
    }
}
