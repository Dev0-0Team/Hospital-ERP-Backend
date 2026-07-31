using FluentValidation;


namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetPatient
{
    internal class GetPatientValidator : AbstractValidator<GetPatientRequest>
    {
        public GetPatientValidator()
        {
            RuleFor(x => x.Id)
               .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
