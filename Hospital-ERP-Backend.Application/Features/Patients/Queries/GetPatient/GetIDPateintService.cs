using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Patients.Queries.GetIDPatient;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Patients.Queries.GetIDPatient
{
    public class GetIDPateintService : IRequestHandler<GetIDPatient, GetIDPatientQuery>
    {
        private readonly IValidator<GetIDPatient> _validator;
        private readonly IBaseQueryRepository<Patient> _iPerson;

        public GetIDPateintService(IValidator<GetIDPatient> validator, IBaseQueryRepository<Patient> iPerson)
        {
            _validator = validator;
            _iPerson = iPerson;
        }

        public async Task<GetIDPatientQuery> Handle(GetIDPatient request, CancellationToken cancellationToken)
        {
            return await GetIDPateintAsync(request);
        }

        private async Task<GetIDPatientQuery> GetIDPateintAsync(GetIDPatient request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var patient = await _iPerson.GetAsync(request.PersonId);

            if (patient == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }

            return new GetIDPatientQuery
            {
                PersonId= request.PersonId
                
            };
        }
    }
}
