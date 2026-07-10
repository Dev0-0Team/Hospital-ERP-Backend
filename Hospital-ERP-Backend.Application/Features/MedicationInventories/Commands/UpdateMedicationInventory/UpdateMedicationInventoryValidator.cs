using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.UpdateMedicationInventory
{
    public class UpdateMedicationInventoryValidator : AbstractValidator<UpdateMedicationInventoryRequest>
    {
        public UpdateMedicationInventoryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be a greater than 0.");

            RuleFor(x => x.MedicationId)
                .GreaterThan(0)
                .WithMessage("Medication Id must be a greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Quantity must be a greater than or equal to 0.");

            RuleFor(x => x.ExpiryDate)
                .NotEmpty()
                .WithMessage("Expiry Date is required.");
        }
    }
}