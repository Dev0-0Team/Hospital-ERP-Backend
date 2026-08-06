using FluentValidation;
namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Queries.GetAllChronicDiseases
{
    internal class GetAllChronicDiseasesValidator : AbstractValidator<GetAllChronicDiseasesRequest>
    {
        public GetAllChronicDiseasesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero");
        }
    }
}
