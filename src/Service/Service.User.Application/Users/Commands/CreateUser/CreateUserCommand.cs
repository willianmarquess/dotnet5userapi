using MediatR;
using Raven.Client.Documents.Session;
using Service.Domain.Users.Entities;
using Service.Domain.Users.Events;
using Service.Infra.Users;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Users.Commands.CreateUser
{

    public class CreateUserCommand : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IAsyncDocumentSession _session;
        private readonly IMediator _mediatr;

        public CreateUserCommandHandler(UserContext userContext, IMediator mediatr)
        {
            _session = userContext.DocumentStore.OpenAsyncSession();
            _mediatr = mediatr;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User(request.Email, request.Password, request.Type)
            {
                Created = DateTime.Now,
                CreatedBy = "admin@admin.com"
            };

            await _session.StoreAsync(entity, cancellationToken);
            await _session.SaveChangesAsync(cancellationToken);

            await _mediatr.Publish(new UserCreatedEvent(entity.Id, entity.Email, entity.Password, entity.Type), cancellationToken);

            return entity;
        }
    }
}
