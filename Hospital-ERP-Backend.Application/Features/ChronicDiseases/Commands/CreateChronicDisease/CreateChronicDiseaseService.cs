using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.CreateChronicDisease
{
    internal class CreateChronicDiseaseService : IRequestHandler<CreateChronicDiseaseRequest, CreateChronicDiseaseResponse>
    {

        private readonly IBaseCommandRepository<ChronicDisease> _chronicDiseaseCommandRepository;
        private readonly IBaseCommandRepository<Patient> _patientRepository;
        private readonly IValidator<CreateChronicDiseaseRequest> _validator;

        public CreateChronicDiseaseService(IBaseCommandRepository<ChronicDisease> chronicDiseaseCommandRepository,IBaseCommandRepository<Patient> patientRepository ,IValidator<CreateChronicDiseaseRequest> validator)
        {
            _chronicDiseaseCommandRepository = chronicDiseaseCommandRepository;
            _validator = validator;
            _patientRepository = patientRepository;
        }
        public async Task<CreateChronicDiseaseResponse> Handle(CreateChronicDiseaseRequest request, CancellationToken cancellationToken)
        {
            return await CreateChronicDiseaseAsync(request);
        }

        private async Task<CreateChronicDiseaseResponse> CreateChronicDiseaseAsync(CreateChronicDiseaseRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool isPatientExist = await _patientRepository.IsExistAsync(request.PatientId);
            if (!isPatientExist)
            {
                throw new KeyNotFoundException($"Patient with id {request.PatientId} not found");
            }

            var chronicDisease = new ChronicDisease
            {
                PatientId = request.PatientId,
                DiseaseName = request.DiseaseName
            };

            ChronicDisease? result = await _chronicDiseaseCommandRepository.CreateAsync(chronicDisease);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create chronic disease.");
            }

            return new CreateChronicDiseaseResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                DiseaseName = result.DiseaseName
            };

        }
    }
}
