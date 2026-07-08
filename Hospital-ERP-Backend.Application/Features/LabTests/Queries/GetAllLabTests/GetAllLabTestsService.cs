using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LapTests.Queries.GetAllLabTests
{
    public class GetAllLabTestsService : IRequestHandler<GetAllLabTestsRequest, IEnumerable<GetAllLabTestsResponse>>
    {
        private readonly IBaseQueryRepository<LabTest> _labTestQueryRepository;

        private readonly IValidator<GetAllLabTestsRequest> _validator;
        public GetAllLabTestsService(IBaseQueryRepository<LabTest> labTestQueryRepository, IValidator<GetAllLabTestsRequest> validator)
        {
            _labTestQueryRepository = labTestQueryRepository;
            _validator = validator;
        }
        public async Task<IEnumerable<GetAllLabTestsResponse>> Handle(GetAllLabTestsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllLabTestsAsync(request);
        }


        private async Task<IEnumerable<GetAllLabTestsResponse>> GetAllLabTestsAsync(GetAllLabTestsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));

            }

            IEnumerable<LabTest> labTests = await _labTestQueryRepository.GetAllAsync(request.Page);

            if (labTests == null || labTests.Count() == 0)
            {
                throw new KeyNotFoundException($"No lab tests found on page {request.Page}.");

            }
            return labTests
                .Select(x => new GetAllLabTestsResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    NormalRange = x.NormalRange
                });
        }
    }
}
