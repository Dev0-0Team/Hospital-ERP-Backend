using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using Microsoft.Identity.Client.Extensibility;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Commands.UpdateRoom
{
    internal class UpdateRoomService : IRequestHandler<UpdateRoomRequest, UpdateRoomResponse>
    {
        private readonly IValidator<UpdateRoomRequest> _validator;
        private readonly IBaseCommandRepository<Department> _departmentRepository;
        private readonly IBaseCommandRepository<RoomType> _roomTypeRepository;
        private readonly IBaseCommandRepository<Room> _iRoom;

        public UpdateRoomService(IValidator<UpdateRoomRequest> validator, IBaseCommandRepository<Room> iRoom, IBaseCommandRepository<Department> departmentRepository, IBaseCommandRepository<RoomType> roomTypeRepository)
        {
            _validator = validator;
            _iRoom = iRoom;
            _departmentRepository = departmentRepository;
            _roomTypeRepository= roomTypeRepository;
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

            bool isDepartmentExist = await _departmentRepository.IsExistAsync(request.DepartmentId);
            if (!isDepartmentExist)
            {
                throw new KeyNotFoundException($"Department with Id {request.DepartmentId} not found.");
            }

            bool isRoomTypeExist = await _roomTypeRepository.IsExistAsync(request.RoomTypeId);
            if (!isRoomTypeExist)
            {
                throw new KeyNotFoundException($"Room Type with Id {request.RoomTypeId} not found.");
            }

            Room? existingRoom = await _iRoom.FindAsync(request.Id);
            if (existingRoom == null)
            {
                throw new KeyNotFoundException($"Room with Id {request.Id} not found.");
            }

            existingRoom.DepartmentId = request.DepartmentId;
            existingRoom.RoomTypeId = request.RoomTypeId;
            existingRoom.RoomNumber = request.RoomNumber;
            existingRoom.Status = request.Status.ToString();
            existingRoom.UpdatedAt = DateTime.UtcNow;

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