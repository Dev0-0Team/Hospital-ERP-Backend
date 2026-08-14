using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Queries.GetEmergencyCase
{
    public class GetEmergencyCaseService : IRequestHandler<GetEmergencyCaseRequest, GetEmergencyCaseResponse>
    {
        private readonly IBaseQueryRepository<EmergencyCase> _repository;
        private readonly IValidator<GetEmergencyCaseRequest> _validator;

        public GetEmergencyCaseService(IBaseQueryRepository<EmergencyCase> repository, IValidator<GetEmergencyCaseRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetEmergencyCaseResponse> Handle(GetEmergencyCaseRequest request, CancellationToken cancellationToken)
        {
            return await GetEmergencyCaseAsync(request);
        }

        private async Task<GetEmergencyCaseResponse> GetEmergencyCaseAsync(GetEmergencyCaseRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            EmergencyCase? emergencyCase = await _repository.GetAsync(request.Id);
            if (emergencyCase == null)
            {
                throw new KeyNotFoundException($"Emergency case with ID {request.Id} not found.");
            }

            return new GetEmergencyCaseResponse
            {
                Id = emergencyCase.Id,
                PatientId = emergencyCase.PatientId,
                Status = emergencyCase.Status,
                TriageColor = emergencyCase.TriageColor,
                ArrivalTime = emergencyCase.ArrivalTime
            };
        }
    }
}
