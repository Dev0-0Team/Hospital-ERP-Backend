using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Queries.GetAllEmergencyContacts
{
    internal class GetAllEmergencyContactsService : IRequestHandler<GetAllEmergencyContactsRequest, IEnumerable<GetAllEmergencyContactsResponse>>
    {
        private readonly IBaseQueryRepository<EmergencyContact> _emergencyContactQueryRepository;

        private readonly IValidator<GetAllEmergencyContactsRequest> _validator;
        public GetAllEmergencyContactsService(IBaseQueryRepository<EmergencyContact> emergencyContactQueryRepository, IValidator<GetAllEmergencyContactsRequest> validator)
        {
            _emergencyContactQueryRepository = emergencyContactQueryRepository;
            _validator = validator;
        }
        public async Task<IEnumerable<GetAllEmergencyContactsResponse>> Handle(GetAllEmergencyContactsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllEmergencyContactsAsync(request);
        }


        private async Task<IEnumerable<GetAllEmergencyContactsResponse>> GetAllEmergencyContactsAsync(GetAllEmergencyContactsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));

            }

            IEnumerable<EmergencyContact> emergencyContacts = await _emergencyContactQueryRepository.GetAllAsync(request.Page);

            if (emergencyContacts == null || emergencyContacts.Count() == 0)
            {
                throw new KeyNotFoundException($"No emergency contacts found on page {request.Page}.");

            }
            return emergencyContacts
                .Select(x => new GetAllEmergencyContactsResponse
                {
                    Id = x.Id,
                    PatientId = x.PatientId,
                    Name = x.Name,
                    Phone = x.Phone,
                    Relationship = x.Relationship
                });
        }
    }
}