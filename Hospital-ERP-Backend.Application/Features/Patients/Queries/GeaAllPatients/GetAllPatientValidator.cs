using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients
{

    public class GetAllPatientValidator : AbstractValidator<GetAllPatient>
    {
        public GetAllPatientValidator()
        {

            RuleFor(x => x.PersonId)

               .GreaterThan(0)
                .WithMessage("Person ID Must be 1 or Greater.");




        }


    }
}


