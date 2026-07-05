using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.UpdateRoomType
{
    public class UpdateRoomTypeService
    {
        private readonly IValidator<UpdateRoomTypeRequest> _validator;
        private readonly IBaseCommandRepository<RoomType> _iRoomType;
        private readonly IBaseQueryRepository<RoomType> _iQueryRoomType;

        public UpdateRoomTypeService(IValidator<UpdateRoomTypeRequest> validator, IBaseCommandRepository<RoomType> iRoomType, IBaseQueryRepository<RoomType> iQueryRoomType)
        {
            _validator = validator;
            _iRoomType = iRoomType;
            _iQueryRoomType = iQueryRoomType;
        }

        public async Task<UpdateRoomTypeResponse> UpdateRoomTypeAsync(UpdateRoomTypeRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            RoomType? existingRoomType = await _iQueryRoomType.GetAsync(request.Id);
            if (existingRoomType == null)
            {
                throw new KeyNotFoundException($"Room type with Id {request.Id} not found.");
            }

            existingRoomType.Name = request.Name;
            RoomType? result = await _iRoomType.UpdateAsync(existingRoomType);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update room type.");
            }

            return new UpdateRoomTypeResponse
            {
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}