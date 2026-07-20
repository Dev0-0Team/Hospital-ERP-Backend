

using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetAllNurses;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients
{
    public class GetAllPatientsService : IRequestHandler<GetAllPatientsRequest, IEnumerable<GetAllPatientsResponse>>
    {
        private readonly IBaseQueryRepository<Patient> _repository;
        private readonly IValidator<GetAllPatientsRequest> _validator;

        public GetAllPatientsService(IBaseQueryRepository<Patient> repository, IValidator<GetAllPatientsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllPatientsResponse>> Handle(GetAllPatientsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllPatientsAsync(request);
        }

        private async Task<IEnumerable<GetAllPatientsResponse>> GetAllPatientsAsync(GetAllPatientsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var patients = await _repository.GetAllAsync(request.Page);

            if (patients == null || patients.Count() == 0)
            {
                throw new KeyNotFoundException($"No patients found on page {request.Page}");
            }

            return patients.Select(x => new GetAllPatientsResponse
            {
                Id = x.Id,
                PersonId = x.PersonId,
                BloodType = x.BloodType
            });
        }
    }
}
