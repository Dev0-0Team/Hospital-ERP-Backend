using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.DeleteChronicDisease
{
    internal class DeleteChronicDiseaseValidator
        : AbstractValidator<DeleteChronicDiseaseRequest>
    {
        public DeleteChronicDiseaseValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than zero.");
        }
    }
}