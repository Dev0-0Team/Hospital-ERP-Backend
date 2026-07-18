using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Queries.GetRoomAssignment
{
    public class GetRoomAssignmentValidator : AbstractValidator<GetRoomAssignmentRequest>
    {
        public GetRoomAssignmentValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Room Assignment Id must be greater than 0.");
        }
    }
}