using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.CreateRoomAssignment
{
    internal class CreateRoomAssignmentService : IRequestHandler<CreateRoomAssignmentRequest, CreateRoomAssignmentResponse>
    {
        private readonly IValidator<CreateRoomAssignmentRequest> _validator;
        private readonly IBaseCommandRepository<RoomAssignment> _iRoomAssignment;
        private readonly IBaseCommandRepository<Patient> _iPatient;
        private readonly IBaseCommandRepository<Bed> _iBed;

        public CreateRoomAssignmentService(IValidator<CreateRoomAssignmentRequest> validator, IBaseCommandRepository<RoomAssignment> iRoomAssignment, IBaseCommandRepository<Bed> iBed, IBaseCommandRepository<Patient> iPatient)
        {
            _validator = validator;
            _iRoomAssignment = iRoomAssignment;
            _iBed = iBed;
            _iPatient = iPatient;
        }

        private async Task<CreateRoomAssignmentResponse> CreateRoomAssignmentAsync(CreateRoomAssignmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool isPatientExist = await _iPatient.IsExistAsync(request.PatientId);
            if (!isPatientExist)
            {
                throw new KeyNotFoundException($"Patient with Id {request.PatientId} not found.");
            }

            bool isBedExist = await _iBed.IsExistAsync(request.BedId);
            if (!isPatientExist)
            {
                throw new KeyNotFoundException($"Bed with Id {request.BedId} not found.");
            }

            RoomAssignment roomAssignment = new RoomAssignment
            {
                PatientId = request.PatientId,
                BedId = request.BedId,
                AdmittedAt = request.AdmittedAt,
                DischargedAt = request.DischargedAt,
            };

            RoomAssignment? result = await _iRoomAssignment.CreateAsync(roomAssignment);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create room assignment.");
            }

            return new CreateRoomAssignmentResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                BedId = result.BedId,
                AdmittedAt = result.AdmittedAt,
                DischargedAt = result.DischargedAt
            };
        }

        public async Task<CreateRoomAssignmentResponse> Handle(CreateRoomAssignmentRequest request, CancellationToken cancellationToken)
        {
            return await CreateRoomAssignmentAsync(request);
        }
    }
}