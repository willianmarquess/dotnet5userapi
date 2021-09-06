using FluentValidation;

namespace Service.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(u => u.Id).NotEmpty().WithMessage("id is required.");
        }
    }
}
