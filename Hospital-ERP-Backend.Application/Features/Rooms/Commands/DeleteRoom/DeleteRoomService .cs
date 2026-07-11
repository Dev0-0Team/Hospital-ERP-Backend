using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomService : IRequestHandler<DeleteRoomRequest, bool>
    {
        private readonly IValidator<DeleteRoomRequest> _validator;
        private readonly IBaseCommandRepository<Room> _iRoom;
        private readonly IBaseQueryRepository<Room> _iRoomQuery;

        public DeleteRoomService(IValidator<DeleteRoomRequest> validator, IBaseCommandRepository<Room> iRoom, IBaseQueryRepository<Room> iRoomQuery)
        {
            _validator = validator;
            _iRoom = iRoom;
            _iRoomQuery = iRoomQuery;
        }

        private async Task<bool> DeleteRoomAsync(DeleteRoomRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var room = await _iRoomQuery.GetAsync(request.Id);
            if (room == null)
            {
                throw new KeyNotFoundException($"Room with Id {request.Id} not found.");
            }
            var isDeleted = await _iRoom.DeleteAsync(room.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete room with Id {request.Id}.");
            }
            return isDeleted;
        }

        public async Task<bool> Handle(DeleteRoomRequest request, CancellationToken cancellationToken)
        {
            return await DeleteRoomAsync(request);
        }
    }
}