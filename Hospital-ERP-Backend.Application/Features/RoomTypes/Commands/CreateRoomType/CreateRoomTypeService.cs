using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.CreateRoomType
{
    public class CreateRoomTypeService : IRequestHandler<CreateRoomTypeRequest, CreateRoomTypeResponse>
    {
        private readonly IValidator<CreateRoomTypeRequest> _validator;
        private readonly IBaseCommandRepository<RoomType> _iRoomType;

        public CreateRoomTypeService(IValidator<CreateRoomTypeRequest> validator, IBaseCommandRepository<RoomType> iRoomType)
        {
            _validator = validator;
            _iRoomType = iRoomType;
        }

        public async Task<CreateRoomTypeResponse> CreateRoomTypeAsync(CreateRoomTypeRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            RoomType roomType = new RoomType
            {
                Name = request.Name,
            };

            RoomType? result = await _iRoomType.CreateAsync(roomType);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create room type.");
            }

            return new CreateRoomTypeResponse()
            {
                Id = result.Id,
                Name = result.Name
            };
        }

        public async Task<CreateRoomTypeResponse> Handle(CreateRoomTypeRequest request, CancellationToken cancellationToken)
        {
         return  await CreateRoomTypeAsync(request);
        }
    }
}