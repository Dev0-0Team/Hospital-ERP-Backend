using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.UpdateChronicDisease
{
    public class UpdateChronicDiseaseService
        : IRequestHandler<UpdateChronicDiseaseRequest, UpdateChronicDiseaseResponse>
    {
        private readonly IValidator<UpdateChronicDiseaseRequest> _validator;
        private readonly IBaseCommandRepository<ChronicDisease> _chronicDiseaseRepository;
        private readonly IBaseQueryRepository<ChronicDisease> _chronicDiseaseQueryRepository;

        public UpdateChronicDiseaseService(IValidator<UpdateChronicDiseaseRequest> validator, IBaseCommandRepository<ChronicDisease> chronicDiseaseRepository,
            IBaseQueryRepository<ChronicDisease> chronicDiseaseQueryRepository)
        {
            _validator = validator;
            _chronicDiseaseRepository = chronicDiseaseRepository;
            _chronicDiseaseQueryRepository = chronicDiseaseQueryRepository;
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

            ChronicDisease? chronicDisease = await _chronicDiseaseQueryRepository.GetAsync(request.Id);

            if (chronicDisease == null)
            {
                throw new KeyNotFoundException($"Chronic disease with id {request.Id} not found");
            }

            chronicDisease.PatientId = request.PatientId;
            chronicDisease.DiseaseName = request.DiseaseName;
            chronicDisease.UpdatedAt = DateTime.Now;

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
