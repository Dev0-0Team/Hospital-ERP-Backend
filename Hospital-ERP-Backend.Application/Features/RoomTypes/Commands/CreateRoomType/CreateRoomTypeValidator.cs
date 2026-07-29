using FluentValidation;
namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.CreateRoomType
{
    internal class CreateRoomTypeValidator : AbstractValidator<CreateRoomTypeRequest>
    {
        public CreateRoomTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Room type name is required.")
                .MaximumLength(100).WithMessage("Room type name must not exceed 100 characters.");
        }
    }
}