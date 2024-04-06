using FluentValidation;

namespace PoliceDepartment.Application.Handlers.UpdatePoliceOfficer;

public class UpdatePoliceOfficerValidator : AbstractValidator<UpdatePoliceOfficerCommand>
{
    public UpdatePoliceOfficerValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull();
    }
}