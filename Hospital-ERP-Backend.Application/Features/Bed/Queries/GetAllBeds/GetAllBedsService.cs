using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Beds.Queries.GetAllBeds
{
    public class GetAllBedsService : IRequestHandler<GetAllBedsRequest, IEnumerable<GetAllBedsResponse>>
    {
        private readonly IValidator<GetAllBedsRequest> _validator;
        private readonly IBaseQueryRepository<Bed> _iBed;

        public GetAllBedsService(IValidator<GetAllBedsRequest> validator, IBaseQueryRepository<Bed> iBed)
        {
            _validator = validator;
            _iBed = iBed;
        }

        private async Task<IEnumerable<GetAllBedsResponse>> GetAllBedsAsync(GetAllBedsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var beds = await _iBed.GetAllAsync(request.Page);
            if (beds == null || beds.Count() == 0)
            {
                throw new KeyNotFoundException($"No beds found on page {request.Page}.");
            }

            return beds.Select(b => new GetAllBedsResponse
            {
                Id = b.Id,
                RoomId = b.RoomId,
                BedNumber = b.BedNumber,
                Status = b.Status
            });
        }

        public async Task<IEnumerable<GetAllBedsResponse>> Handle(GetAllBedsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllBedsAsync(request);
        }
    }
}