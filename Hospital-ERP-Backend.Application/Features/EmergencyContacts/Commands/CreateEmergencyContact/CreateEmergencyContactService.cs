using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.CreateEmergencyContact
{
    public class CreateEmergencyContactService : IRequestHandler<CreateEmergencyContactRequest, CreateEmergencyContactResponse>
    {

        private readonly IBaseCommandRepository<EmergencyContact> _emergencyContactCommandRepository;
        private readonly IValidator<CreateEmergencyContactRequest> _validator;

        public CreateEmergencyContactService(IBaseCommandRepository<EmergencyContact> emergencyContactCommandRepository, IValidator<CreateEmergencyContactRequest> validator)
        {
            _emergencyContactCommandRepository = emergencyContactCommandRepository;
            _validator = validator;
        }
        public async Task<CreateEmergencyContactResponse> Handle(CreateEmergencyContactRequest request, CancellationToken cancellationToken)
        {
            return await CreateEmergencyContactAsync(request);
        }

        private async Task<CreateEmergencyContactResponse> CreateEmergencyContactAsync(CreateEmergencyContactRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var emergencyContact = new EmergencyContact
            {
                PatientId = request.PatientId,
                Name = request.Name,
                Phone = request.Phone,
                Relationship = request.Relationship
            };

            EmergencyContact? result = await _emergencyContactCommandRepository.CreateAsync(emergencyContact);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create emergency contact.");
            }

            return new CreateEmergencyContactResponse
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