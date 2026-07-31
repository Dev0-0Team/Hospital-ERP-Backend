using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Commands.DeleteMedicationInventory
{
    internal class DeleteMedicationInventoryValidator : AbstractValidator<DeleteMedicationInventoryRequest>
    {
        public DeleteMedicationInventoryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Medication Inventory Id must be greater than 0.");
        }
    }
}