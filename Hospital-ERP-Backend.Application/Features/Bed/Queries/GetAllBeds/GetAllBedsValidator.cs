using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Beds.Queries.GetAllBeds
{
    internal class GetAllBedsValidator : AbstractValidator<GetAllBedsRequest>
    {
        public GetAllBedsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}