using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Medications.Queries.GetAllMedications
{
    public class GetAllMedicationsValidator : AbstractValidator<GetAllMedicationsRequest>
    {
        public GetAllMedicationsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero");
        }
    }
}