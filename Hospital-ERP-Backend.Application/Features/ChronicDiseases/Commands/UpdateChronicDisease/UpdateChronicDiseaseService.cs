using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.UpdateChronicDisease
{
    internal class UpdateChronicDiseaseService
        : IRequestHandler<UpdateChronicDiseaseRequest, UpdateChronicDiseaseResponse>
    {
        private readonly IValidator<UpdateChronicDiseaseRequest> _validator;
        private readonly IBaseCommandRepository<ChronicDisease> _chronicDiseaseRepository;
        private readonly IBaseCommandRepository<Patient> _patientRepository;

        public UpdateChronicDiseaseService(IValidator<UpdateChronicDiseaseRequest> validator, IBaseCommandRepository<ChronicDisease> chronicDiseaseRepository,
            IBaseCommandRepository<Patient> patientRepository)
        {
            _validator = validator;
            _chronicDiseaseRepository = chronicDiseaseRepository;
            _patientRepository = patientRepository;
        }

        public async Task<UpdateChronicDiseaseResponse> Handle(UpdateChronicDiseaseRequest request, CancellationToken cancellationToken)
        {
            return await UpdateChronicDiseaseAsync(request);
        }

        private async Task<UpdateChronicDiseaseResponse> UpdateChronicDiseaseAsync(UpdateChronicDiseaseRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool isPatientExist = await _patientRepository.IsExistAsync(request.PatientId);
            if (!isPatientExist)
            {
                throw new KeyNotFoundException($"Patient with id {request.Id} not found");
            }

            ChronicDisease? chronicDisease = await _chronicDiseaseRepository.FindAsync(request.Id);

            if (chronicDisease == null)
            {
                throw new KeyNotFoundException($"Chronic disease with id {request.Id} not found");
            }

            chronicDisease.PatientId = request.PatientId;
            chronicDisease.DiseaseName = request.DiseaseName;
            chronicDisease.UpdatedAt = DateTime.UtcNow;

            var result = await _chronicDiseaseRepository.UpdateAsync(chronicDisease);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update chronic disease");
            }

            return new UpdateChronicDiseaseResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                DiseaseName = result.DiseaseName
            };
        }
    }
}
