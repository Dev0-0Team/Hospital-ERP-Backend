using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.LabTests.Queries.GetLabTest
{
    internal class GetLabTestService : IRequestHandler<GetLabTestRequest, GetLabTestResponse>
    {
        private readonly IBaseQueryRepository<LabTest> _labTestQueryRepostitory;
        private readonly IValidator<GetLabTestRequest> _validator;
        public GetLabTestService(IBaseQueryRepository<LabTest> labTestQueryRepository, IValidator<GetLabTestRequest> validator)
        {
            _labTestQueryRepostitory = labTestQueryRepository;
            _validator = validator;
        }
        public async Task<GetLabTestResponse> Handle(GetLabTestRequest request, CancellationToken cancellationToken)
        {
            return await GetLabTestAsync(request);
        }

        private async Task<GetLabTestResponse> GetLabTestAsync(GetLabTestRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            LabTest? labTest = await _labTestQueryRepostitory.GetAsync(request.Id);
            if (labTest == null)
            {
                throw new KeyNotFoundException($"Lab test with ID {request.Id} not found.");
            }
            return new GetLabTestResponse
            {
                Id = labTest.Id,
                Name = labTest.Name,
                NormalRange = labTest.NormalRange
            };
        }
    }
}
