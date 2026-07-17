using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetAllPatients
{
    public class GetAllPatientService : IRequestHandler<GetAllPatient,IEnumerable< GetAllPatientQuery>>
    {
        private readonly IValidator<GetAllPatient> _validator;
        private readonly IBaseQueryRepository<Patient> _iPerson;

        public GetAllPatientService(IValidator<GetAllPatient> validator, IBaseQueryRepository<Patient> iPerson)
        {
            _validator = validator;
            _iPerson = iPerson;
        }

        public async Task<IEnumerable<GetAllPatientQuery>> Handle(GetAllPatient request, CancellationToken cancellationToken)
        {
            return await GetAllPatientAsync(request);
        }

        private async Task<IEnumerable<GetAllPatientQuery>> GetAllPatientAsync(GetAllPatient request)
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
            return patientList.Select(p=>new GetAllPatientQuery
            {
             PersonId=p.PersonId,
            BloodType=p.BloodType
            });
        }
    }
}
