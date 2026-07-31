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

        public CreateRoomAssignmentService(IValidator<CreateRoomAssignmentRequest> validator, IBaseCommandRepository<RoomAssignment> iRoomAssignment)
        {
            _validator = validator;
            _iRoomAssignment = iRoomAssignment;
        }

        private async Task<CreateRoomAssignmentResponse> CreateRoomAssignmentAsync(CreateRoomAssignmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            RoomAssignment roomAssignment = new RoomAssignment
            {
                PatientId = request.PatientId,
                BedId = request.BedId,
                AdmittedAt = request.AdmittedAt.GetValueOrDefault(),
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