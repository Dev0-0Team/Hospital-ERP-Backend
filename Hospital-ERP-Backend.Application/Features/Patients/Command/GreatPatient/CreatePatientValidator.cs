using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Patients.Command.GreatPatient
{
   
        public class CreatePatientValidator : AbstractValidator<CreatePatient>
        {
            public CreatePatientValidator()
            {
                // Full Name
                RuleFor(x => x.PersonId)
                    
                   .GreaterThan(0)
                    .WithMessage("Person ID Must be 1 or Greater.");

                // Date of Birth
                RuleFor(x => x.BloodType)
                    .NotEmpty()
                    .WithMessage("Blood type is required.");

             
            }

           
        }
    }


