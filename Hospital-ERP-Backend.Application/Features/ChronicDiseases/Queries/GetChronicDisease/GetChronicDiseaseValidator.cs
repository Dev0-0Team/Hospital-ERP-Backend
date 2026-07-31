using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Queries.GetChronicDisease
{
    internal class GetChronicDiseaseValidator : AbstractValidator<GetChronicDiseaseRequest>
    {

        public GetChronicDiseaseValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than zero");

        }
    }
}
