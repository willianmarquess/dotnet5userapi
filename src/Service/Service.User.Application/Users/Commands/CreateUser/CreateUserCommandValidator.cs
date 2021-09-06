using FluentValidation;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Service.Domain.Users.Entities;
using Service.Infra.Users;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IAsyncDocumentSession _session;

        public CreateUserCommandValidator(UserContext userContext)
        {
            _session = userContext.DocumentStore.OpenAsyncSession();
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("E-mail is required.")
                .MustAsync(VerifyUniqueEmail).WithMessage("The specified e-mail already exists.");
            RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is required.");
        }

        private async Task<bool> VerifyUniqueEmail(string email, CancellationToken cancellationToken)
        {
            var user = await _session.Query<User>().FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
            return user is null;
        }
    }
}
