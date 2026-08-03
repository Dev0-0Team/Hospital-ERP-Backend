using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyCases.Commands.DeleteEmergencyCases
{
    public class DeleteEmergencyCasesService : IRequestHandler<DeleteEmergencyCasesRequest, bool>
    {
        private readonly IBaseCommandRepository<EmergencyCase> _commandRepository;
        private readonly IBaseQueryRepository<EmergencyCase> _queryRepository;
        private readonly IValidator<DeleteEmergencyCasesRequest> _validator;

        public DeleteEmergencyCasesService(
            IBaseCommandRepository<EmergencyCase> commandRepository,
            IBaseQueryRepository<EmergencyCase> queryRepository,
            IValidator<DeleteEmergencyCasesRequest> validator)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteEmergencyCasesRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEmergencyCaseAsync(request);
        }

        private async Task<bool> DeleteEmergencyCaseAsync(DeleteEmergencyCasesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            EmergencyCase? emergencyCase = await _queryRepository.GetAsync(request.Id);

            if (emergencyCase == null)
            {
                throw new KeyNotFoundException($"Emergency Case with Id {request.Id} not found.");
            }

            return await _commandRepository.DeleteAsync(request.Id);
        }
    }
}
