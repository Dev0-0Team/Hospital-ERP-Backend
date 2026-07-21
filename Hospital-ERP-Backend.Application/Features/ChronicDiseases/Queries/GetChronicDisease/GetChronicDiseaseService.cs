using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Queries.GetChronicDisease
{
    public class GetChronicDiseaseService : IRequestHandler<GetChronicDiseaseRequest, GetChronicDiseaseResponse>
    {
        private readonly IBaseQueryRepository<ChronicDisease> _chronicDiseaseQueryRepository;
        private readonly IValidator<GetChronicDiseaseRequest> _validator;
        public GetChronicDiseaseService(IBaseQueryRepository<ChronicDisease> chronicDiseaseQueryRepository, IValidator<GetChronicDiseaseRequest> validator)
        {
            _chronicDiseaseQueryRepository = chronicDiseaseQueryRepository;
            _validator = validator;
        }
        public async Task<GetChronicDiseaseResponse> Handle(GetChronicDiseaseRequest request, CancellationToken cancellationToken)
        {
            return await GetChronicDiseaseAsync(request);
        }

        private async Task<GetChronicDiseaseResponse> GetChronicDiseaseAsync(GetChronicDiseaseRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            ChronicDisease? chronicDisease = await _chronicDiseaseQueryRepository.GetAsync(request.Id);
            if (chronicDisease == null)
            {
                throw new KeyNotFoundException($"Chronic disease with ID {request.Id} not found.");
            }
            return new GetChronicDiseaseResponse
            {
                Id = chronicDisease.Id,
                PatientId = chronicDisease.PatientId,
                DiseaseName = chronicDisease.DiseaseName
            };
        }
    }
}
