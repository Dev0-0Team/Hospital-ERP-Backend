using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Queries.GetPrescriptionItem
{
    internal class GetPrescriptionItemValidator : AbstractValidator<GetPrescriptionItemRequest>
    {
        public GetPrescriptionItemValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Prescription Item Id must be greater than 0.");
        }
    }
}