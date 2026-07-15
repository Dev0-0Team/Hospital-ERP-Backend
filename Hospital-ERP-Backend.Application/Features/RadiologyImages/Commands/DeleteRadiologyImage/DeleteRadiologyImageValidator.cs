using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.DeleteRadiologyImage
{
    public class DeleteRadiologyImageValidator
        : AbstractValidator<DeleteRadiologyImageRequest>
    {
        public DeleteRadiologyImageValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Radiology Image Id must be greater than 0.");
        }
    }
}