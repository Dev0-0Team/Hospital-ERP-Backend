using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Commands.DeletePrescriptionItem
{
    internal class DeletePrescriptionItemValidator : AbstractValidator<DeletePrescriptionItemRequest>
    {
        public DeletePrescriptionItemValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Prescription Item Id must be greater than 0.");
        }
    }
}