using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Beds.Commands.UpdateBed
{
    internal class UpdateBedService : IRequestHandler<UpdateBedRequest, UpdateBedResponse>
    {
        private readonly IValidator<UpdateBedRequest> _validator;
        private readonly IBaseCommandRepository<Bed> _iBed;
        public UpdateBedService(IValidator<UpdateBedRequest> validator, IBaseCommandRepository<Bed> iBed)
        {
            _validator = validator;
            _iBed = iBed;
        }

        public async Task<UpdateBedResponse> Handle(UpdateBedRequest request, CancellationToken cancellationToken)
        {
            return await UpdateBedAsync(request);
        }

        private async Task<UpdateBedResponse> UpdateBedAsync(UpdateBedRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Bed? existingBed = await _iBed.FindAsync(request.Id);
            if (existingBed == null)
            {
                throw new KeyNotFoundException($"Bed with Id {request.Id} not found.");
            }

            existingBed.RoomId = request.RoomId;
            existingBed.BedNumber = request.BedNumber;
            existingBed.Status = request.Status.ToString();

            Bed? result = await _iBed.UpdateAsync(existingBed);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update bed.");
            }

            return new UpdateBedResponse
            {
                Id = result.Id,
                RoomId = result.RoomId,
                BedNumber = result.BedNumber,
                Status = result.Status
            };
        }
    }
}