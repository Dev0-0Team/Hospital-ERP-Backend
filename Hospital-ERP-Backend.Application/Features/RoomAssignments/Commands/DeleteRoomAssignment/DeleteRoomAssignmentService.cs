using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RoomAssignments.Commands.DeleteRoomAssignment
{
    internal class DeleteRoomAssignmentService : IRequestHandler<DeleteRoomAssignmentRequest, bool>
    {
        private readonly IValidator<DeleteRoomAssignmentRequest> _validator;
        private readonly IBaseCommandRepository<RoomAssignment> _iRoomAssignment;
        private readonly IBaseQueryRepository<RoomAssignment> _iRoomAssignmentQuery;

        public DeleteRoomAssignmentService(IValidator<DeleteRoomAssignmentRequest> validator, IBaseCommandRepository<RoomAssignment> iRoomAssignment, IBaseQueryRepository<RoomAssignment> iRoomAssignmentQuery)
        {
            _validator = validator;
            _iRoomAssignment = iRoomAssignment;
            _iRoomAssignmentQuery = iRoomAssignmentQuery;
        }

        private async Task<bool> DeleteRoomAssignmentAsync(DeleteRoomAssignmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var roomAssignment = await _iRoomAssignmentQuery.GetAsync(request.Id);
            if (roomAssignment == null)
            {
                throw new KeyNotFoundException($"Room Assignment with Id {request.Id} not found.");
            }

            // Soft delete: sets IsDeleted = true and DeletedAt, record stays in the database
            // and is excluded from query results.
            var isDeleted = await _iRoomAssignment.DeleteAsync(roomAssignment.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete room assignment with Id {request.Id}.");
            }
            return isDeleted;
        }

        public async Task<bool> Handle(DeleteRoomAssignmentRequest request, CancellationToken cancellationToken)
        {
            return await DeleteRoomAssignmentAsync(request);
        }
    }
}