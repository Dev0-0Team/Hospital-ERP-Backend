using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Queries.GetAllChronicDiseases
{
    public class GetAllChronicDiseasesService : IRequestHandler<GetAllChronicDiseasesRequest, IEnumerable<GetAllChronicDiseasesResponse>>
    {
        private readonly IBaseQueryRepository<ChronicDisease> _chronicDiseaseQueryRepository;

        private readonly IValidator<GetAllChronicDiseasesRequest> _validator;
        public GetAllChronicDiseasesService(IBaseQueryRepository<ChronicDisease> chronicDiseaseQueryRepository, IValidator<GetAllChronicDiseasesRequest> validator)
        {
            _chronicDiseaseQueryRepository = chronicDiseaseQueryRepository;
            _validator = validator;
        }
        public async Task<IEnumerable<GetAllChronicDiseasesResponse>> Handle(GetAllChronicDiseasesRequest request, CancellationToken cancellationToken)
        {
            return await GetAllChronicDiseasesAsync(request);
        }


        private async Task<IEnumerable<GetAllChronicDiseasesResponse>> GetAllChronicDiseasesAsync(GetAllChronicDiseasesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));

            }

            IEnumerable<ChronicDisease> chronicDiseases = await _chronicDiseaseQueryRepository.GetAllAsync(request.Page);

            if (chronicDiseases == null || chronicDiseases.Count() == 0)
            {
                throw new KeyNotFoundException($"No chronic diseases found on page {request.Page}.");

            }
            return chronicDiseases
                .Select(x => new GetAllChronicDiseasesResponse
                {
                    Id = x.Id,
                    PatientId = x.PatientId,
                    DiseaseName = x.DiseaseName
                });
        }
    }
}
