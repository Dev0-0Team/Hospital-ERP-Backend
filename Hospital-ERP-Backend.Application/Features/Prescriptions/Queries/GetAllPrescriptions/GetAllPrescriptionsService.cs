using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Prescriptions.Queries.GetAllPrescriptions
{
    internal class GetAllPrescriptionsService : IRequestHandler<GetAllPrescriptionsRequest,
            IEnumerable<GetAllPrescriptionsResponse>>
    {
        private readonly IBaseQueryRepository<Prescription> _repository;

        private readonly IValidator<GetAllPrescriptionsRequest> _validator;

        public GetAllPrescriptionsService(IBaseQueryRepository<Prescription> repository, IValidator<GetAllPrescriptionsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllPrescriptionsResponse>> Handle(GetAllPrescriptionsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllPrescriptionsAsync(request);
        }

        private async Task<IEnumerable<GetAllPrescriptionsResponse>> GetAllPrescriptionsAsync(GetAllPrescriptionsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            IEnumerable<Prescription> prescriptions = await _repository.GetAllAsync(request.Page);

            if (!prescriptions.Any())
            {
                throw new KeyNotFoundException($"No prescriptions found on page {request.Page}.");
            }

            return prescriptions.Select(x =>
                new GetAllPrescriptionsResponse
                {
                    Id = x.Id,
                    PatientId = x.PatientId,
                    DoctorId = x.DoctorId
                });
        }
    }
}