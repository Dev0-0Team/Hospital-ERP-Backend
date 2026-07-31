using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Commands.UpdateRoom
{
    internal class UpdateRoomService : IRequestHandler<UpdateRoomRequest, UpdateRoomResponse>
    {
        private readonly IValidator<UpdateRoomRequest> _validator;
        private readonly IBaseCommandRepository<Room> _iRoom;
        private readonly IBaseQueryRepository<Room> _iQueryRoom;

        public UpdateRoomService(IValidator<UpdateRoomRequest> validator, IBaseCommandRepository<Room> iRoom, IBaseQueryRepository<Room> iQueryRoom)
        {
            _validator = validator;
            _iRoom = iRoom;
            _iQueryRoom = iQueryRoom;
        }

        public async Task<UpdateRoomResponse> Handle(UpdateRoomRequest request, CancellationToken cancellationToken)
        {
            return await UpdateRoomAsync(request);
        }

        private async Task<UpdateRoomResponse> UpdateRoomAsync(UpdateRoomRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Room? existingRoom = await _iQueryRoom.GetAsync(request.Id);
            if (existingRoom == null)
            {
                throw new KeyNotFoundException($"Room with Id {request.Id} not found.");
            }

            existingRoom.DepartmentId = request.DepartmentId;
            existingRoom.RoomTypeId = request.RoomTypeId;
            existingRoom.RoomNumber = request.RoomNumber;
            existingRoom.Status = request.Status;

            Room? result = await _iRoom.UpdateAsync(existingRoom);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update room.");
            }

            return new UpdateRoomResponse
            {
                Id = result.Id,
                DepartmentId = result.DepartmentId,
                RoomTypeId = result.RoomTypeId,
                RoomNumber = result.RoomNumber,
                Status = result.Status
            };
        }
    }
}