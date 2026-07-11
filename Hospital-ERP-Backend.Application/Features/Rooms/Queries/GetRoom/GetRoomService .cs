using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Queries.GetRoom
{
    public class GetRoomService : IRequestHandler<GetRoomRequest, GetRoomResponse>
    {
        private readonly IValidator<GetRoomRequest> _validator;
        private readonly IBaseQueryRepository<Room> _iRoom;

        public GetRoomService(IValidator<GetRoomRequest> validator, IBaseQueryRepository<Room> iRoom)
        {
            _validator = validator;
            _iRoom = iRoom;
        }

        private async Task<GetRoomResponse> GetRoomAsync(GetRoomRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var room = await _iRoom.GetAsync(request.Id);
            if (room == null)
            {
                throw new KeyNotFoundException($"Room with Id {request.Id} not found.");
            }

            return new GetRoomResponse
            {
                Id = room.Id,
                DepartmentId = room.DepartmentId,
                RoomTypeId = room.RoomTypeId,
                RoomNumber = room.RoomNumber,
                Status = room.Status
            };
        }

        public async Task<GetRoomResponse> Handle(GetRoomRequest request, CancellationToken cancellationToken)
        {
            return await GetRoomAsync(request);
        }
    }
}