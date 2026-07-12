using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetPrescription
{
    public class GetPrescriptionValidator : AbstractValidator<GetPrescriptionRequest>
    {
        public GetPrescriptionValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Prescription Id must be greater than 0.");
        }
    }
}