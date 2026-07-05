using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Medications.Queries.GetAllMedications
{
    public class GetAllMedicationsService : IRequestHandler<GetAllMedicationsRequest, List<GetAllMedicationsResponse>>
    {
        private readonly IBaseQueryRepository<Medication> _medicationQueryRepository;

        private readonly IValidator<GetAllMedicationsRequest> _validator;

        public GetAllMedicationsService(IBaseQueryRepository<Medication> medicationQueryRepository, IValidator<GetAllMedicationsRequest> validator)
        {
            _medicationQueryRepository = medicationQueryRepository;
            _validator = validator;
        }

        public async Task<List<GetAllMedicationsResponse>> Handle(GetAllMedicationsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllMedicationsAsync(request);
        }

        private async Task<List<GetAllMedicationsResponse>> GetAllMedicationsAsync(GetAllMedicationsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            IEnumerable<Medication> medications = await _medicationQueryRepository.GetAllAsync(request.Page);

            return medications
                .Select(x => new GetAllMedicationsResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    DosageForm = x.DosageForm,
                    Manufacturer = x.Manufacturer ?? string.Empty
                })
                .ToList();
        }
    }
}