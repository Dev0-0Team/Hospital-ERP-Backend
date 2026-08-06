using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Rooms.Queries.GetAllRooms
{
    internal class GetAllRoomsService : IRequestHandler<GetAllRoomsRequest, IEnumerable<GetAllRoomsResponse>>
    {
        private readonly IValidator<GetAllRoomsRequest> _validator;
        private readonly IBaseQueryRepository<Room> _iRoom;

        public GetAllRoomsService(IValidator<GetAllRoomsRequest> validator, IBaseQueryRepository<Room> iRoom)
        {
            _validator = validator;
            _iRoom = iRoom;
        }

        private async Task<IEnumerable<GetAllRoomsResponse>> GetAllRoomsAsync(GetAllRoomsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var rooms = await _iRoom.GetAllAsync(request.Page);
            if (rooms == null || rooms.Count() == 0)
            {
                throw new KeyNotFoundException($"No rooms found on page {request.Page}.");
            }

            return rooms.Select(r => new GetAllRoomsResponse
            {
                Id = r.Id,
                DepartmentId = r.DepartmentId,
                RoomTypeId = r.RoomTypeId,
                RoomNumber = r.RoomNumber,
                Status = r.Status
            });
        }

        public async Task<IEnumerable<GetAllRoomsResponse>> Handle(GetAllRoomsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllRoomsAsync(request);
        }
    }
}