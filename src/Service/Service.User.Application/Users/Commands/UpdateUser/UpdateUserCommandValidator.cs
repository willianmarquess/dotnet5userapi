using FluentValidation;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Service.Domain.Users.Entities;
using Service.Infra.Users;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IAsyncDocumentSession _session;

        public UpdateUserCommandValidator(UserContext userContext)
        {
            _session = userContext.DocumentStore.OpenAsyncSession();
            RuleFor(u => u.Id).NotEmpty().WithMessage("Id is required.")
                .MustAsync(VerifyUserExists).WithMessage("The user with this id not exists.");
            RuleFor(u => u.Email).NotEmpty().WithMessage("E-mail is required.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is required.");
        }

        private async Task<bool> VerifyUserExists(string id, CancellationToken cancellationToken)
        {
            var user = await _session.Query<User>().FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            return user is not null;
        }
    }
}
