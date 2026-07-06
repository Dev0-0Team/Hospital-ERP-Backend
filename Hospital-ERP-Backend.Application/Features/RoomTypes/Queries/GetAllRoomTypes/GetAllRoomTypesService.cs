

using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetAllPersons;
using Hospital_ERP_Backend.Application.Features.Persons.Queries.GetPerson;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetAllRoomTypes
{
    public class GetAllRoomTypesService : IRequestHandler<GetAllRoomTypesRequest, IEnumerable<GetAllRoomTypesResponse>>
    {
        private readonly IValidator<GetAllRoomTypesRequest> _validator;
        private readonly IBaseQueryRepository<RoomType> _iRoomType;

        public GetAllRoomTypesService(IValidator<GetAllRoomTypesRequest> validator, IBaseQueryRepository<RoomType> iRoomType)
        {
            _validator = validator;
            _iRoomType = iRoomType;
        }

        public async Task<IEnumerable<GetAllRoomTypesResponse>> GetAllRoomTypesAsync(GetAllRoomTypesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var roomTypes = await _iRoomType.GetAllAsync(request.Page);
            if (roomTypes == null || roomTypes.Count() == 0)
            {
                throw new KeyNotFoundException($"No room types found on page {request.Page}.");
            }

            return roomTypes.Select(r => new GetAllRoomTypesResponse
            {
                Id = r.Id,
                Name = r.Name
            });
        }

        public async Task<IEnumerable<GetAllRoomTypesResponse>> Handle(GetAllRoomTypesRequest request, CancellationToken cancellationToken)
        {
           return await GetAllRoomTypesAsync(request);
        }
    }
}
