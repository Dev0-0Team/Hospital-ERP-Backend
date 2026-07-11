using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomValidator : AbstractValidator<DeleteRoomRequest>
    {
        public DeleteRoomValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}