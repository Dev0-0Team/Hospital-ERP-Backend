using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetAllRadiologyImages
{
    public class GetAllRadiologyImagesValidator
        : AbstractValidator<GetAllRadiologyImagesRequest>
    {
        public GetAllRadiologyImagesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than zero.");
        }
    }
}