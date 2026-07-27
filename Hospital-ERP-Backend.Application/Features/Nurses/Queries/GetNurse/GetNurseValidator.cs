

using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetNurse
{
    internal class GetNurseValidator : AbstractValidator<GetNurseRequest>
    {
        public GetNurseValidator()
        {
            RuleFor(x =>x.Id)
               .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
