using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.UpdateRoomAssignment
{
    internal class UpdateRoomAssignmentService : IRequestHandler<UpdateRoomAssignmentRequest, UpdateRoomAssignmentResponse>
    {
        private readonly IValidator<UpdateRoomAssignmentRequest> _validator;
        private readonly IBaseCommandRepository<RoomAssignment> _iRoomAssignment;
        private readonly IBaseQueryRepository<RoomAssignment> _iQueryRoomAssignment;

        public UpdateRoomAssignmentService(IValidator<UpdateRoomAssignmentRequest> validator, IBaseCommandRepository<RoomAssignment> iRoomAssignment, IBaseQueryRepository<RoomAssignment> iQueryRoomAssignment)
        {
            _validator = validator;
            _iRoomAssignment = iRoomAssignment;
            _iQueryRoomAssignment = iQueryRoomAssignment;
        }

        public async Task<UpdateRoomAssignmentResponse> Handle(UpdateRoomAssignmentRequest request, CancellationToken cancellationToken)
        {
            return await UpdateRoomAssignmentAsync(request);
        }

        private async Task<UpdateRoomAssignmentResponse> UpdateRoomAssignmentAsync(UpdateRoomAssignmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            RoomAssignment? existingRoomAssignment = await _iQueryRoomAssignment.GetAsync(request.Id);
            if (existingRoomAssignment == null)
            {
                throw new KeyNotFoundException($"Room Assignment with Id {request.Id} not found.");
            }

            existingRoomAssignment.PatientId = request.PatientId;
            existingRoomAssignment.BedId = request.BedId;
            existingRoomAssignment.AdmittedAt = request.AdmittedAt;
            existingRoomAssignment.DischargedAt = request.DischargedAt;

            RoomAssignment? result = await _iRoomAssignment.UpdateAsync(existingRoomAssignment);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update room assignment.");
            }

            return new UpdateRoomAssignmentResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                BedId = result.BedId,
                AdmittedAt = result.AdmittedAt,
                DischargedAt = result.DischargedAt
            };
        }
    }
}