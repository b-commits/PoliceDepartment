using FluentValidation;

namespace PoliceDepartment.Application.Handlers.CreatePoliceOfficer;

internal sealed class CreatePoliceOfficerValidator : AbstractValidator<CreatePoliceOfficerCommand>
{
    public CreatePoliceOfficerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}