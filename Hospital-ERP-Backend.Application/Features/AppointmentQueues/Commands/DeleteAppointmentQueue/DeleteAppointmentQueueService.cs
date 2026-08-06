using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.DeleteAppointmentQueue
{
    internal class DeleteAppointmentQueueService : IRequestHandler<DeleteAppointmentQueueRequest, bool>
    {
        private readonly IValidator<DeleteAppointmentQueueRequest> _validator;
        private readonly IBaseCommandRepository<AppointmentQueue> _iAppointmentQueue;

        public DeleteAppointmentQueueService(IValidator<DeleteAppointmentQueueRequest> validator, IBaseCommandRepository<AppointmentQueue> iAppointmentQueue)
        {
            _validator = validator;
            _iAppointmentQueue = iAppointmentQueue;
        }

        public async Task<bool> Handle(DeleteAppointmentQueueRequest request, CancellationToken cancellationToken)
        {
            return await DeleteAppointmentQueueAsync(request);
        }

        private async Task<bool> DeleteAppointmentQueueAsync(DeleteAppointmentQueueRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool appointmentQueue = await _iAppointmentQueue.IsExistAsync(request.Id);
            if (!appointmentQueue)
            {
                throw new KeyNotFoundException($"Appointment queue with Id {request.Id} not found.");
            }

            // Soft delete: BaseCommandRepository.DeleteAsync flags IsDeleted/DeletedAt
            // instead of physically removing the row from the table.
            var isDeleted = await _iAppointmentQueue.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete appointment queue with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}