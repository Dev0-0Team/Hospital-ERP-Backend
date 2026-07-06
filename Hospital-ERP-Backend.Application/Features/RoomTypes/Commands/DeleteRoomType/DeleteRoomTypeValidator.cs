using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.DeleteRoomType
{
    public class DeleteRoomTypeValidator : AbstractValidator<DeleteRoomTypeRequest>
    {
        public DeleteRoomTypeValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}