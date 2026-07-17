using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Patients.Command.UpdatePatient
{
    

    
    
        public class UpdatePatientValidator : AbstractValidator<UpdatePatient>
        {
            public UpdatePatientValidator()
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


