

using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients
{
    internal class GetAllPatientsValidator : AbstractValidator<GetAllPatientsRequest>
    {
        public GetAllPatientsValidator()
        {
            RuleFor(x => x.Page)
               .GreaterThan(0).WithMessage("Page must be greater than 0.");
        }
    }
}
