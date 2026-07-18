using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetIDPatient
{

    public class GetPatientValidator : AbstractValidator<GetPateintRequest>
    {
        public GetPatientValidator()
        {

            RuleFor(x => x.PersonId)

               .GreaterThan(0)
                .WithMessage("Patient ID Must be 1 or Greater.");




        }


    }
}


