using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.DeleteRoomAssignment
{
    public class DeleteRoomAssignmentValidator : AbstractValidator<DeleteRoomAssignmentRequest>
    {
        public DeleteRoomAssignmentValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}