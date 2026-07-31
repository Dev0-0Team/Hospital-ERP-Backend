using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Beds.Queries.GetBed
{
    internal class GetBedValidator : AbstractValidator<GetBedRequest>
    {
        public GetBedValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Bed Id must be greater than 0.");
        }
    }
}