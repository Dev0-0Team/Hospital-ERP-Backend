using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.DeleteEmergencyCases
{
    public class DeleteEmergencyCasesValidator : AbstractValidator<DeleteEmergencyCasesRequest>
    {
        public DeleteEmergencyCasesValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than zero.");
        }
    }
}
