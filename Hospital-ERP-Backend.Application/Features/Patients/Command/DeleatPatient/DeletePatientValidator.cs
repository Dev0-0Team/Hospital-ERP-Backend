using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Patients.Command.DeletePatient
{

    public class DeletePatientValidator : AbstractValidator<DeletePatient>
    {
        public DeletePatientValidator()
        {
            
            RuleFor(x => x.PersonId)

               .GreaterThan(0)
                .WithMessage("Person ID Must be 1 or Greater.");

           


        }


    }
}


