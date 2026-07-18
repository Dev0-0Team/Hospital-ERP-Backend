using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients
{
    public class GetAllPatientService : IRequestHandler<GetAllPatientRequest, IEnumerable<GetAllPateintResponse>>
    {
        private readonly IValidator<GetAllPatientRequest> _validator;
        private readonly IBaseQueryRepository<Patient> _iPerson;

        public GetAllPatientService(IValidator<GetAllPatientRequest> validator, IBaseQueryRepository<Patient> iPerson)
        {
            _validator = validator;
            _iPerson = iPerson;
        }

        public async Task<IEnumerable<GetAllPateintResponse>> Handle(GetAllPatientRequest request, CancellationToken cancellationToken)
        {
            return await GetAllPatientAsync(request);
        }

        private async Task<IEnumerable<GetAllPateintResponse>> GetAllPatientAsync(GetAllPatientRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var patients = await _iPerson.GetAsync(request.PersonId);

            if (patients == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }

            var patientList = await _iPerson.GetAllAsync(1);
            return patientList.Select(p=>new GetAllPateintResponse
            {
             PersonId=p.PersonId,
            BloodType=p.BloodType
            });
        }
    }
}
