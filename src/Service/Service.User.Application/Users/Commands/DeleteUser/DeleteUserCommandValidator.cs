using FluentValidation;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Service.Domain.Users.Entities;
using Service.Infra.Users;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        private readonly IAsyncDocumentSession _session;

        public DeleteUserCommandValidator(UserContext userContext)
        {
            _session = userContext.DocumentStore.OpenAsyncSession();
            RuleFor(u => u.Id).NotEmpty().WithMessage("Id is required.")
                .MustAsync(VerifyUserExists).WithMessage("The user with this id not exists.");
        }

        private async Task<bool> VerifyUserExists(string id, CancellationToken cancellationToken)
        {
            var user = await _session.Query<User>().FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            return user is not null;
        }
    }
}
