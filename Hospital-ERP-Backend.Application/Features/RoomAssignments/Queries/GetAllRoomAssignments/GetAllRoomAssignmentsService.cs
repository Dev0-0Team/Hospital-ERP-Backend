using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Queries.GetAllRoomAssignments
{
    internal class GetAllRoomAssignmentsService : IRequestHandler<GetAllRoomAssignmentsRequest, IEnumerable<GetAllRoomAssignmentsResponse>>
    {
        private readonly IValidator<GetAllRoomAssignmentsRequest> _validator;
        private readonly IBaseQueryRepository<RoomAssignment> _iRoomAssignment;

        public GetAllRoomAssignmentsService(IValidator<GetAllRoomAssignmentsRequest> validator, IBaseQueryRepository<RoomAssignment> iRoomAssignment)
        {
            _validator = validator;
            _iRoomAssignment = iRoomAssignment;
        }

        private async Task<IEnumerable<GetAllRoomAssignmentsResponse>> GetAllRoomAssignmentsAsync(GetAllRoomAssignmentsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var roomAssignments = await _iRoomAssignment.GetAllAsync(request.Page);
            if (roomAssignments == null || roomAssignments.Count() == 0)
            {
                throw new KeyNotFoundException($"No room assignments found on page {request.Page}.");
            }

            return roomAssignments.Select(ra => new GetAllRoomAssignmentsResponse
            {
                Id = ra.Id,
                PatientId = ra.PatientId,
                BedId = ra.BedId,
                AdmittedAt = ra.AdmittedAt,
                DischargedAt = ra.DischargedAt
            });
        }

        public async Task<IEnumerable<GetAllRoomAssignmentsResponse>> Handle(GetAllRoomAssignmentsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllRoomAssignmentsAsync(request);
        }
    }
}