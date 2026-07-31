using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Beds.Commands.CreateBed
{
    internal class CreateBedService : IRequestHandler<CreateBedRequest, CreateBedResponse>
    {
        private readonly IValidator<CreateBedRequest> _validator;
        private readonly IBaseCommandRepository<Bed> _iBed;

        public CreateBedService(IValidator<CreateBedRequest> validator, IBaseCommandRepository<Bed> iBed)
        {
            _validator = validator;
            _iBed = iBed;
        }

        private async Task<CreateBedResponse> CreateBedAsync(CreateBedRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Bed bed = new Bed
            {
                RoomId = request.RoomId,
                BedNumber = request.BedNumber,
                Status = request.Status,
            };

            Bed? result = await _iBed.CreateAsync(bed);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create bed.");
            }

            return new CreateBedResponse
            {
                Id = result.Id,
                RoomId = result.RoomId,
                BedNumber = result.BedNumber,
                Status = result.Status
            };
        }

        public async Task<CreateBedResponse> Handle(CreateBedRequest request, CancellationToken cancellationToken)
        {
            return await CreateBedAsync(request);
        }
    }
}