using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.CreatePrescription
{
    internal class CreatePrescriptionValidator : AbstractValidator<CreatePrescriptionRequest>
    {
        public CreatePrescriptionValidator()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0)
                .WithMessage("Patient Id must be greater than 0.");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0)
                .WithMessage("Doctor Id must be greater than 0.");
        }
    }
}