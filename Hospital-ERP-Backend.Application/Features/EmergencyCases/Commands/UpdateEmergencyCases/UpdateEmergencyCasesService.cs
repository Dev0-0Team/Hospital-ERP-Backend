using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.UpdateEmergencyCases
{
    public class UpdateEmergencyCasesService : IRequestHandler<UpdateEmergencyCasesRequest, UpdateEmergencyCasesResponse>
    {
        private readonly IValidator<UpdateEmergencyCasesRequest> _validator;
        private readonly IBaseCommandRepository<EmergencyCase> _commandRepository;

        public UpdateEmergencyCasesService(
            IValidator<UpdateEmergencyCasesRequest> validator,
            IBaseCommandRepository<EmergencyCase> commandRepository)        {
            _validator = validator;
            _commandRepository = commandRepository;
        }

        public async Task<UpdateEmergencyCasesResponse> Handle(UpdateEmergencyCasesRequest request, CancellationToken cancellationToken)
        {
            return await UpdateEmergencyCaseAsync(request);
        }

        private async Task<UpdateEmergencyCasesResponse> UpdateEmergencyCaseAsync(UpdateEmergencyCasesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            EmergencyCase? emergencyCase = await _commandRepository.FindAsync(request.Id);

            if (emergencyCase == null)
            {
                throw new KeyNotFoundException($"Emergency case with id {request.Id} not found");
            }

            emergencyCase.PatientId = request.PatientId;
            emergencyCase.Status = request.Status;
            emergencyCase.TriageColor = request.TriageColor;
            emergencyCase.ArrivalTime = request.ArrivalTime;
            emergencyCase.UpdatedAt = DateTime.Now;

            var result = await _commandRepository.UpdateAsync(emergencyCase);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update emergency case.");
            }

            return new UpdateEmergencyCasesResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                Status = result.Status,
                TriageColor = result.TriageColor,
                ArrivalTime = result.ArrivalTime
            };
        }
    }
}
