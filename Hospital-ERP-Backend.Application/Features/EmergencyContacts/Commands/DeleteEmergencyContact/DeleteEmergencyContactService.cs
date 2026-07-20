using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.EmergencyContacts.Commands.DeleteEmergencyContact
{
    public class DeleteEmergencyContactService : IRequestHandler<DeleteEmergencyContactRequest, bool>
    {
        private readonly IBaseCommandRepository<EmergencyContact> _emergencyContactCommandRepo;
        private readonly IBaseQueryRepository<EmergencyContact> _emergencyContactQueryRepo;

        private readonly IValidator<DeleteEmergencyContactRequest> _validator;
        public DeleteEmergencyContactService(IBaseCommandRepository<EmergencyContact> emergencyContactCommandRepo, IBaseQueryRepository<EmergencyContact> emergencyContactQueryRepo, IValidator<DeleteEmergencyContactRequest> validator)
        {
            _emergencyContactCommandRepo = emergencyContactCommandRepo;
            _emergencyContactQueryRepo = emergencyContactQueryRepo;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteEmergencyContactRequest request, CancellationToken cancellationToken)
        {
            return await DeleteEmergencyContactAsync(request);
        }

        private async Task<bool> DeleteEmergencyContactAsync(DeleteEmergencyContactRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            EmergencyContact? emergencyContact = await _emergencyContactQueryRepo.GetAsync(request.Id);
            if (emergencyContact == null)
            {
                throw new ArgumentException($"Emergency contact with ID {request.Id} not found.");
            }

            var isDeleted = await _emergencyContactCommandRepo.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new ArgumentException($"Failed to delete emergency contact with ID {request.Id}.");
            }

            return isDeleted;
        }
    }
}