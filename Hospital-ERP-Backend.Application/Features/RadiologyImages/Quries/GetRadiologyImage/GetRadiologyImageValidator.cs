using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetRadiologyImage
{
    public class GetRadiologyImageValidator
        : AbstractValidator<GetRadiologyImageRequest>
    {
        public GetRadiologyImageValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Radiology Image Id must be greater than 0.");
        }
    }
}