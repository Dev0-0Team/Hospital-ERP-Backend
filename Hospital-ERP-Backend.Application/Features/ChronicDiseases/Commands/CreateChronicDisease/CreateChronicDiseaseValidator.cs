using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.CreateChronicDisease
{
    public class CreateChronicDiseaseValidator : AbstractValidator<CreateChronicDiseaseRequest>
    {
        public CreateChronicDiseaseValidator()
        {
            // Patient Id
            RuleFor(x => x.PatientId)
                .GreaterThan(0)
                .WithMessage("Patient id must be greater than zero");

            // Disease Name
            RuleFor(x => x.DiseaseName)
                .NotEmpty()
                .WithMessage("Disease name is required")
                .MaximumLength(150)
                .WithMessage("Disease name must not exceed 150 characters");
        }
    }
}
