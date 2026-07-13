using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Queries.GetPrescriptionItem
{
    public class GetPrescriptionItemValidator : AbstractValidator<GetPrescriptionItemRequest>
    {
        public GetPrescriptionItemValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Prescription Item Id must be greater than 0.");
        }
    }
}