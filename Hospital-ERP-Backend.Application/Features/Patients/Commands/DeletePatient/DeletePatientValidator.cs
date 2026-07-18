using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Patients.Commands.DeletePatient
{

    public class DeletePatientValidator : AbstractValidator<DeletePatientRequest>
    {
        public DeletePatientValidator()
        {
            
            RuleFor(x => x.Id)

               .GreaterThan(0)
                .WithMessage("Person ID Must be 1 or Greater.");

           


        }


    }
}


