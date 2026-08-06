using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Queries.GetRoom
{
    internal class GetRoomValidator : AbstractValidator<GetRoomRequest>
    {
        public GetRoomValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Room Id must be greater than 0.");
        }
    }
}