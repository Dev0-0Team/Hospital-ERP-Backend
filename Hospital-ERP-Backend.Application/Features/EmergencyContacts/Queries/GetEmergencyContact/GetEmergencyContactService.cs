using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Queries.GetEmergencyContact
{
    public class GetEmergencyContactService : IRequestHandler<GetEmergencyContactRequest, GetEmergencyContactResponse>
    {
        private readonly IBaseQueryRepository<EmergencyContact> _emergencyContactQueryRepostitory;
        private readonly IValidator<GetEmergencyContactRequest> _validator;
        public GetEmergencyContactService(IBaseQueryRepository<EmergencyContact> emergencyContactQueryRepository, IValidator<GetEmergencyContactRequest> validator)
        {
            _emergencyContactQueryRepostitory = emergencyContactQueryRepository;
            _validator = validator;
        }
        public async Task<GetEmergencyContactResponse> Handle(GetEmergencyContactRequest request, CancellationToken cancellationToken)
        {
            return await GetEmergencyContactAsync(request);
        }

        private async Task<GetEmergencyContactResponse> GetEmergencyContactAsync(GetEmergencyContactRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            EmergencyContact? emergencyContact = await _emergencyContactQueryRepostitory.GetAsync(request.Id);
            if (emergencyContact == null)
            {
                throw new KeyNotFoundException($"Emergency contact with ID {request.Id} not found.");
            }
            return new GetEmergencyContactResponse
            {
                Id = emergencyContact.Id,
                PatientId = emergencyContact.PatientId,
                Name = emergencyContact.Name,
                Phone = emergencyContact.Phone,
                Relationship = emergencyContact.Relationship
            };
        }
    }
}