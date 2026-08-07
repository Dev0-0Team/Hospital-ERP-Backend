using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Commands.UpdateSurgeriesHistory
{
    internal class UpdateSurgeriesHistoryValidator : AbstractValidator<UpdateSurgeriesHistoryRequest>
    {
        public UpdateSurgeriesHistoryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
            
            RuleFor(x => x.PatientId).GreaterThan(0)
                .WithMessage("Patient Id must be greater than 0.");
            
            RuleFor(x => x.SurgeryName)
                .NotEmpty().WithMessage("Name is Required")
                .MaximumLength(150)
                .WithMessage("Surgery Name must not exceed 150 characters");

            RuleFor(x => x.SurgeryDate)
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("Surgery date cannot be in the future.");
        }
    }
}