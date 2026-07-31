

using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.UpdatePatient
{
    internal class UpdatePatientValidator : AbstractValidator<UpdatePatientRequest>
    {
        public UpdatePatientValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID must be greater than 0.");

            RuleFor(x => x.PersonId)
                .GreaterThan(0).WithMessage("Person ID must be greater than 0.");

            RuleFor(x => x.BloodType)
                .MaximumLength(10).WithMessage("Blood type must not exceed 50 characters.");
        }
    }
}
