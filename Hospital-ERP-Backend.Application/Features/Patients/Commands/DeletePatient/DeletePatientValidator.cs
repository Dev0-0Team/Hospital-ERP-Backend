

using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.DeletePatient
{
    internal class DeletePatientValidator : AbstractValidator<DeletePatientRequest>
    {
        public DeletePatientValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
