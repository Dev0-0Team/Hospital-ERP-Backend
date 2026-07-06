using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.DeleteRoomType
{
    public class DeleteRoomTypeService : IRequestHandler<DeleteRoomTypeRequest, bool>
    {
        private readonly IValidator<DeleteRoomTypeRequest> _validator;
        private readonly IBaseCommandRepository<RoomType> _iRoomType;
        private readonly IBaseQueryRepository<RoomType> _iRoomTypeQuery;

        public DeleteRoomTypeService(IValidator<DeleteRoomTypeRequest> validator, IBaseCommandRepository<RoomType> iRoomType, IBaseQueryRepository<RoomType> iRoomTypeQuery)
        {
            _validator = validator;
            _iRoomType = iRoomType;
            _iRoomTypeQuery = iRoomTypeQuery;
        }

        private async Task<bool> DeleteRoomTypeAsync(DeleteRoomTypeRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var roomType = await _iRoomTypeQuery.GetAsync(request.Id);
            if (roomType == null)
            {
                throw new KeyNotFoundException($"Room type with Id {request.Id} not found.");
            }
            var isDeleted = await _iRoomType.DeleteAsync(roomType.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete room type with Id {request.Id}.");
            }
            return isDeleted;
        }

        public async Task<bool> Handle(DeleteRoomTypeRequest request, CancellationToken cancellationToken)
        {
           return await DeleteRoomTypeAsync(request);
        }
    }
}