using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Queries.GetAllEmergencyCases
{
    public class GetAllEmergencyCasesService : IRequestHandler<GetAllEmergencyCasesRequest, IEnumerable<GetAllEmergencyCasesResponse>>
    {
        private readonly IBaseQueryRepository<EmergencyCase> _repository;
        private readonly IValidator<GetAllEmergencyCasesRequest> _validator;

        public GetAllEmergencyCasesService(IBaseQueryRepository<EmergencyCase> repository, IValidator<GetAllEmergencyCasesRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllEmergencyCasesResponse>> Handle(GetAllEmergencyCasesRequest request, CancellationToken cancellationToken)
        {
            return await GetAllEmergencyCasesAsync(request);
        }

        private async Task<IEnumerable<GetAllEmergencyCasesResponse>> GetAllEmergencyCasesAsync(GetAllEmergencyCasesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            IEnumerable<EmergencyCase> cases = await _repository.GetAllAsync(request.Page);

            if (cases == null || !cases.Any())
            {
                throw new KeyNotFoundException($"No emergency cases found on page {request.Page}.");
            }

            return cases.Select(x => new GetAllEmergencyCasesResponse
            {
                Id = x.Id,
                PatientId = x.PatientId,
                Status = x.Status,
                TriageColor = x.TriageColor,
                ArrivalTime = x.ArrivalTime
            });
        }
    }
}
