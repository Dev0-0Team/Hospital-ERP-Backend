using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Commands.CreateRoom
{
    internal class CreateRoomService : IRequestHandler<CreateRoomRequest, CreateRoomResponse>
    {
        private readonly IValidator<CreateRoomRequest> _validator;
        private readonly IBaseCommandRepository<Room> _iRoom;

        public CreateRoomService(IValidator<CreateRoomRequest> validator, IBaseCommandRepository<Room> iRoom)
        {
            _validator = validator;
            _iRoom = iRoom;
        }

        private async Task<CreateRoomResponse> CreateRoomAsync(CreateRoomRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Room room = new Room
            {
                DepartmentId = request.DepartmentId,
                RoomTypeId = request.RoomTypeId,
                RoomNumber = request.RoomNumber,
                Status = request.Status,
            };

            Room? result = await _iRoom.CreateAsync(room);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create room.");
            }

            return new CreateRoomResponse()
            {
                Id = result.Id,
                DepartmentId = result.DepartmentId,
                RoomTypeId = result.RoomTypeId,
                RoomNumber = result.RoomNumber,
                Status = result.Status
            };
        }

        public async Task<CreateRoomResponse> Handle(CreateRoomRequest request, CancellationToken cancellationToken)
        {
            return await CreateRoomAsync(request);
        }
    }
}