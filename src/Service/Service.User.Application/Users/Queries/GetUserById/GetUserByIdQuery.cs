using MediatR;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Service.Domain.Users.Entities;
using Service.Infra.Users;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public string Id { get; set; }
    }
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IAsyncDocumentSession _session;

        public GetUserByIdQueryHandler(UserContext userContext)
        {
            _session = userContext.DocumentStore.OpenAsyncSession();
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _session.Query<User>().FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        }
    }
}
