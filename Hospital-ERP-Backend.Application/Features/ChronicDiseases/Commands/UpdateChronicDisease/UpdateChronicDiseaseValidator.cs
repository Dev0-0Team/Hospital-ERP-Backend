using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.UpdateChronicDisease
{
    public class UpdateChronicDiseaseValidator : AbstractValidator<UpdateChronicDiseaseRequest>
    {
        public UpdateChronicDiseaseValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be a positive integer.");

            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Patient id must be a positive integer.");

            RuleFor(x => x.DiseaseName)
                .NotEmpty().WithMessage("Disease name is required.")
                .MaximumLength(150).WithMessage("Disease name must not exceed 150 characters.");
        }
    }
}
