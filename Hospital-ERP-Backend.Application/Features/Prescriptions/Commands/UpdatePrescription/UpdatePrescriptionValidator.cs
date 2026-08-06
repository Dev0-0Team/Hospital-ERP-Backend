using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.UpdatePrescription
{
    internal class UpdatePrescriptionValidator : AbstractValidator<UpdatePrescriptionRequest>
    {
        public UpdatePrescriptionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be a greater than 0.");

            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("PatientId must be a greater than 0.");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("DoctorId must be a greater than 0.");
        }
    }
}