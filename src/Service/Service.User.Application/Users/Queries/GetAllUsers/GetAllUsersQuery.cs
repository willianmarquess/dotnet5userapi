using MediatR;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Service.Domain.Users.Entities;
using Service.Infra.Users;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IAsyncDocumentSession _session;

        public GetAllUsersQueryHandler(UserContext userContext)
        {
            _session = userContext.DocumentStore.OpenAsyncSession();
        }
        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _session.Query<User>().ToListAsync(cancellationToken);
        }
    }
}
