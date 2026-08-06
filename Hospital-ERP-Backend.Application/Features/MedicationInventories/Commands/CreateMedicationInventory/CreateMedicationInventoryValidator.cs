using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.CreateMedicationInventory
{
    internal class CreateMedicationInventoryValidator : AbstractValidator<CreateMedicationInventoryRequest>
    {
        public CreateMedicationInventoryValidator()
        {
            RuleFor(x => x.MedicationId)
                .GreaterThan(0)
                .WithMessage("Medication Id must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Quantity can not be negative.");

            RuleFor(x => x.ExpiryDate)
                .GreaterThan(DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("Expiry date must be in the future.");
        }
    }
}