using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.UpdateRadiologyImage
{
    public class UpdateRadiologyImageValidator
        : AbstractValidator<UpdateRadiologyImageRequest>
    {
        public UpdateRadiologyImageValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.RadiologyOrderId)
                .GreaterThan(0).WithMessage("Radiology order ID must be greater than 0.");

            RuleFor(x => x.ImageUrl)
                 .NotEmpty().WithMessage("Image must be not empty.")
                .MaximumLength(500).WithMessage("Image url must not exceed 500 characters.");
        }
    }
}