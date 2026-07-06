using FluentValidation;
namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.UpdateRoomType
{
    public class UpdateRoomTypeValidator : AbstractValidator<UpdateRoomTypeRequest>
    {
        public UpdateRoomTypeValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        }
    }
}