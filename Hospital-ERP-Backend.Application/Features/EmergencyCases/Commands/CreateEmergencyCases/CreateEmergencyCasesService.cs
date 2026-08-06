using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.CreateEmergencyCases;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.CreateEmergencyCases
{
    public class CreateEmergencyCasesService : IRequestHandler<CreateEmergencyCasesRequest, CreateEmergencyCasesResponse>
    {
        private readonly IBaseCommandRepository<EmergencyCase> _repository;
        private readonly IValidator<CreateEmergencyCasesRequest> _validator;

        public CreateEmergencyCasesService(IBaseCommandRepository<EmergencyCase> repository,
            IValidator<CreateEmergencyCasesRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateEmergencyCasesResponse> Handle(CreateEmergencyCasesRequest request,
            CancellationToken cancellationToken)
        {
            return await CreateEmergencyCaseAsync(request);
        }

        private async Task<CreateEmergencyCasesResponse> CreateEmergencyCaseAsync(CreateEmergencyCasesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            EmergencyCase emergencyCase = new()
            {
                PatientId = request.PatientId,
                Status = request.Status,
                TriageColor = request.TriageColor,
                ArrivalTime = request.ArrivalTime
            };

            EmergencyCase? result = await _repository.CreateAsync(emergencyCase);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Emergency Case.");
            }

            return new CreateEmergencyCasesResponse
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