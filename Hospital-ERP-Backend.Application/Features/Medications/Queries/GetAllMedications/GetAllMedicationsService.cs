using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Medications.Queries.GetAllMedications
{
    internal class GetAllMedicationsService : IRequestHandler<GetAllMedicationsRequest, IEnumerable<GetAllMedicationsResponse>>
    {
        private readonly IBaseQueryRepository<Medication> _medicationQueryRepository;

        private readonly IValidator<GetAllMedicationsRequest> _validator;

        public GetAllMedicationsService(IBaseQueryRepository<Medication> medicationQueryRepository, IValidator<GetAllMedicationsRequest> validator)
        {
            _medicationQueryRepository = medicationQueryRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllMedicationsResponse>> Handle(GetAllMedicationsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllMedicationsAsync(request);
        }

        private async Task<IEnumerable<GetAllMedicationsResponse>> GetAllMedicationsAsync(GetAllMedicationsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            IEnumerable<Medication> medications = await _medicationQueryRepository.GetAllAsync(request.Page);

            if (medications == null || medications.Count() == 0)
            {
                throw new KeyNotFoundException($"No medications found on page {request.Page}.");
            }

            return medications
                .Select(x => new GetAllMedicationsResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    DosageForm = x.DosageForm,
                    Manufacturer = x.Manufacturer ?? string.Empty
                });
        }
    }
}