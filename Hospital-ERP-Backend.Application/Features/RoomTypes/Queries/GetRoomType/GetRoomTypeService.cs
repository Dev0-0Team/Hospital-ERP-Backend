using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetRoomType
{
    public class GetRoomTypeService
    {
        private readonly IValidator<GetRoomTypeRequest> _validator;
        private readonly IBaseQueryRepository<RoomType> _iRoomType;

        public GetRoomTypeService(IValidator<GetRoomTypeRequest> validator, IBaseQueryRepository<RoomType> iRoomType)
        {
            _validator = validator;
            _iRoomType = iRoomType;
        }

        public async Task<GetRoomTypeResponse> GetRoomTypeAsync(GetRoomTypeRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var roomType = await _iRoomType.GetAsync(request.Id);
            if (roomType == null)
            {
                throw new KeyNotFoundException($"Room type with Id {request.Id} not found.");
            }

            return new GetRoomTypeResponse
            {
                Id = roomType.Id,
                Name = roomType.Name
            };
        }
    }
}