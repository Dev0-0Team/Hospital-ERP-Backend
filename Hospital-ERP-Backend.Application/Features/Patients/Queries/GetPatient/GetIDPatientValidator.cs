using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetIDPatient
{

    public class GetIDPatientValidator : AbstractValidator<GetIDPatient>
    {
        public GetIDPatientValidator()
        {

            RuleFor(x => x.PersonId)

               .GreaterThan(0)
                .WithMessage("Patient ID Must be 1 or Greater.");




        }


    }
}


