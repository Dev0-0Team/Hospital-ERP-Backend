using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Queries.GetAllRoomAssignments
{
    public class GetAllRoomAssignmentsValidator : AbstractValidator<GetAllRoomAssignmentsRequest>
    {
        public GetAllRoomAssignmentsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}