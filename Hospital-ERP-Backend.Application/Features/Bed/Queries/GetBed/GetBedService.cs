using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Beds.Queries.GetBed
{
    internal class GetBedService : IRequestHandler<GetBedRequest, GetBedResponse>
    {
        private readonly IValidator<GetBedRequest> _validator;
        private readonly IBaseQueryRepository<Bed> _iBed;

        public GetBedService(IValidator<GetBedRequest> validator, IBaseQueryRepository<Bed> iBed)
        {
            _validator = validator;
            _iBed = iBed;
        }

        private async Task<GetBedResponse> GetBedAsync(GetBedRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var bed = await _iBed.GetAsync(request.Id);
            if (bed == null)
            {
                throw new KeyNotFoundException($"Bed with Id {request.Id} not found.");
            }

            return new GetBedResponse
            {
                Id = bed.Id,
                RoomId = bed.RoomId,
                BedNumber = bed.BedNumber,
                Status = bed.Status
            };
        }

        public async Task<GetBedResponse> Handle(GetBedRequest request, CancellationToken cancellationToken)
        {
            return await GetBedAsync(request);
        }
    }
}