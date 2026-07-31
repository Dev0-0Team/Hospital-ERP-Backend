using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.UpdateAppointmentQueue
{
    internal class UpdateAppointmentQueueService : IRequestHandler<UpdateAppointmentQueueRequest, UpdateAppointmentQueueResponse>
    {
        private readonly IValidator<UpdateAppointmentQueueRequest> _validator;
        private readonly IBaseCommandRepository<AppointmentQueue> _iAppointmentQueue;
        private readonly IBaseQueryRepository<AppointmentQueue> _iAppointmentQueueQuery;

        public UpdateAppointmentQueueService(IValidator<UpdateAppointmentQueueRequest> validator, IBaseCommandRepository<AppointmentQueue> iAppointmentQueue, IBaseQueryRepository<AppointmentQueue> iAppointmentQueueQuery)
        {
            _validator = validator;
            _iAppointmentQueue = iAppointmentQueue;
            _iAppointmentQueueQuery = iAppointmentQueueQuery;
        }

        public async Task<UpdateAppointmentQueueResponse> Handle(UpdateAppointmentQueueRequest request, CancellationToken cancellationToken)
        {
            return await UpdateAppointmentQueueAsync(request);
        }

        private async Task<UpdateAppointmentQueueResponse> UpdateAppointmentQueueAsync(UpdateAppointmentQueueRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            AppointmentQueue? existingAppointmentQueue = await _iAppointmentQueueQuery.GetAsync(request.Id);
            if (existingAppointmentQueue == null)
            {
                throw new KeyNotFoundException($"Appointment queue with Id {request.Id} not found.");
            }

            existingAppointmentQueue.AppointmentId = request.AppointmentId;
            existingAppointmentQueue.QueueNumber = request.QueueNumber;
            existingAppointmentQueue.EstimatedTime = request.EstimatedTime;
            existingAppointmentQueue.Status = request.Status;
            existingAppointmentQueue.UpdatedAt = DateTime.Now;

            AppointmentQueue? result = await _iAppointmentQueue.UpdateAsync(existingAppointmentQueue);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update appointment queue.");
            }

            return new UpdateAppointmentQueueResponse
            {
                Id = result.Id,
                AppointmentId = result.AppointmentId,
                QueueNumber = result.QueueNumber,
                EstimatedTime = result.EstimatedTime,
                Status = result.Status
            };
        }
    }
}