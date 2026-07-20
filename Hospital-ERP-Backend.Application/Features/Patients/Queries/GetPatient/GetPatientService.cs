using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetNurse;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetPatient
{
    public class GetPatientService : IRequestHandler<GetPatientRequest, GetPatientResponse>
    {

        private readonly IBaseQueryRepository<Patient> _repository;
        private readonly IValidator<GetPatientRequest> _validator;
        public GetPatientService(IBaseQueryRepository<Patient> repository, IValidator<GetPatientRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetPatientResponse> Handle(GetPatientRequest request, CancellationToken cancellationToken)
        {
            return await GetPatientAsync(request);
        }

        private async Task<GetPatientResponse> GetPatientAsync(GetPatientRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Patient? patient = await _repository.GetAsync(request.Id);

            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with Id {request.Id} not found.");
            }

            return new GetPatientResponse
            {
                Id = patient.Id,
                PersonId = patient.PersonId,
                BloodType = patient.BloodType
            };
        }
    }
}
