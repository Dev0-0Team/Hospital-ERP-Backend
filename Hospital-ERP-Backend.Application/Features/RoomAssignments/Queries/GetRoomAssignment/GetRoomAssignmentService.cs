using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Queries.GetRoomAssignment
{
    public class GetRoomAssignmentService : IRequestHandler<GetRoomAssignmentRequest, GetRoomAssignmentResponse>
    {
        private readonly IValidator<GetRoomAssignmentRequest> _validator;
        private readonly IBaseQueryRepository<RoomAssignment> _iRoomAssignment;

        public GetRoomAssignmentService(IValidator<GetRoomAssignmentRequest> validator, IBaseQueryRepository<RoomAssignment> iRoomAssignment)
        {
            _validator = validator;
            _iRoomAssignment = iRoomAssignment;
        }

        private async Task<GetRoomAssignmentResponse> GetRoomAssignmentAsync(GetRoomAssignmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var roomAssignment = await _iRoomAssignment.GetAsync(request.Id);
            if (roomAssignment == null)
            {
                throw new KeyNotFoundException($"Room Assignment with Id {request.Id} not found.");
            }

            return new GetRoomAssignmentResponse
            {
                Id = roomAssignment.Id,
                PatientId = roomAssignment.PatientId,
                BedId = roomAssignment.BedId,
                AdmittedAt = roomAssignment.AdmittedAt,
                DischargedAt = roomAssignment.DischargedAt
            };
        }

        public async Task<GetRoomAssignmentResponse> Handle(GetRoomAssignmentRequest request, CancellationToken cancellationToken)
        {
            return await GetRoomAssignmentAsync(request);
        }
    }
}