using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.UpdateEmergencyContact
{
    internal class UpdateEmergencyContactService
        : IRequestHandler<UpdateEmergencyContactRequest, UpdateEmergencyContactResponse>
    {
        private readonly IValidator<UpdateEmergencyContactRequest> _validator;
        private readonly IBaseCommandRepository<EmergencyContact> _emergencyContactRepository;
        private readonly IBaseQueryRepository<EmergencyContact> _emergencyContactQueryRepository;

        public UpdateEmergencyContactService(IValidator<UpdateEmergencyContactRequest> validator, IBaseCommandRepository<EmergencyContact> emergencyContactRepository,
            IBaseQueryRepository<EmergencyContact> emergencyContactQueryRepository)
        {
            _validator = validator;
            _emergencyContactRepository = emergencyContactRepository;
            _emergencyContactQueryRepository = emergencyContactQueryRepository;
        }

        public async Task<UpdateEmergencyContactResponse> Handle(UpdateEmergencyContactRequest request, CancellationToken cancellationToken)
        {
            return await UpdateEmergencyContactAsync(request);
        }

        private async Task<UpdateEmergencyContactResponse> UpdateEmergencyContactAsync(UpdateEmergencyContactRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            EmergencyContact? emergencyContact = await _emergencyContactQueryRepository.GetAsync(request.Id);

            if (emergencyContact == null)
            {
                throw new KeyNotFoundException($"Emergency Contact with id {request.Id} not found");
            }

            emergencyContact.PatientId = request.PatientId;
            emergencyContact.Name = request.Name;
            emergencyContact.Phone = request.Phone;
            emergencyContact.Relationship = request.Relationship;
            emergencyContact.UpdatedAt = DateTime.Now;

            var result = await _emergencyContactRepository.UpdateAsync(emergencyContact);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update emergency contact");
            }

            return new UpdateEmergencyContactResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                Name = result.Name,
                Phone = result.Phone,
                Relationship = result.Relationship
            };
        }
    }
}