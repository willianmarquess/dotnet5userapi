using MediatR;
using Raven.Client.Documents.Session;
using Service.Domain.Users.Entities;
using Service.Domain.Users.Events;
using Service.Infra.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public string Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IAsyncDocumentSession _session;
        private readonly IMediator _mediatr;

        public DeleteUserCommandHandler(UserContext userContext, IMediator mediatr)
        {
            _session = userContext.DocumentStore.OpenAsyncSession();
            _mediatr = mediatr;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _session.Delete(request.Id);
            await _session.SaveChangesAsync(cancellationToken);
            await _mediatr.Publish(new UserDeletedEvent(request.Id), cancellationToken);
            return Unit.Value;
        }
    }
}
