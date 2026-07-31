using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Queries.GetAllMedicationInventories
{
    internal class GetAllMedicationInventoriesValidator : AbstractValidator<GetAllMedicationInventoriesRequest>
    {
        public GetAllMedicationInventoriesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero.");
        }
    }
}