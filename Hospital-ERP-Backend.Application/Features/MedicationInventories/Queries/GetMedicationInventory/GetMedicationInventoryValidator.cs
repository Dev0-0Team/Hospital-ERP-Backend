using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Queries.GetMedicationInventory
{
    public class GetMedicationInventoryValidator
        : AbstractValidator<GetMedicationInventoryRequest>
    {
        public GetMedicationInventoryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Medication Inventory Id must be greater than 0.");
        }
    }
}