
using FluentValidation;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetAllRoomTypes
{
    public class GetAllRoomTypesValidator : AbstractValidator<GetAllRoomTypesRequest>
    {
        public GetAllRoomTypesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        }
    }
}