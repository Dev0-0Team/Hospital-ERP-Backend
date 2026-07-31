using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Commands.DeleteRoom
{
    internal class DeleteRoomService : IRequestHandler<DeleteRoomRequest, bool>
    {
        private readonly IValidator<DeleteRoomRequest> _validator;
        private readonly IBaseCommandRepository<Room> _iRoom;

        public DeleteRoomService(IValidator<DeleteRoomRequest> validator, IBaseCommandRepository<Room> iRoom)
        {
            _validator = validator;
            _iRoom = iRoom;
        }

        private async Task<bool> DeleteRoomAsync(DeleteRoomRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var room = await _iRoom.IsExistAsync(request.Id);
            if (!room)
            {
                throw new KeyNotFoundException($"Room with Id {request.Id} not found.");
            }
            var isDeleted = await _iRoom.DeleteAsync(request.Id);
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