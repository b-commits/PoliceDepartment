using FluentValidation;

namespace PoliceDepartment.Application.Handlers.SignIn;

public class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    public SignInCommandValidator()
    {
        RuleFor(x => x.email).NotNull().NotEmpty();
        RuleFor(x => x.username).NotNull().NotEmpty();
    }
}