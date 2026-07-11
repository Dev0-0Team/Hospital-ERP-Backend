using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Queries.GetAllRooms
{
    public class GetAllRoomsValidator : AbstractValidator<GetAllRoomsRequest>
    {
        public GetAllRoomsValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}