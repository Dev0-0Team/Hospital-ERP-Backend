using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetRoomType
{
    public class GetRoomTypeValidator : AbstractValidator<GetRoomTypeRequest>
    {
        public GetRoomTypeValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Room type Id must be greater than 0.");
        }
    }
}