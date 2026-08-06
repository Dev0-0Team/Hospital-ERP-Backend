using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Commands.DeletePrescription
{
    internal class DeletePrescriptionValidator : AbstractValidator<DeletePrescriptionRequest>
    {
        public DeletePrescriptionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Prescription Id must be greater than 0.");
        }
    }
}