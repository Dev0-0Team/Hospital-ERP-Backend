using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Queries.GetAppointmentQueue
{
    public class GetAppointmentQueueService : IRequestHandler<GetAppointmentQueueRequest, GetAppointmentQueueResponse>
    {
        private readonly IValidator<GetAppointmentQueueRequest> _validator;
        private readonly IBaseQueryRepository<AppointmentQueue> _iAppointmentQueue;

        public GetAppointmentQueueService(IValidator<GetAppointmentQueueRequest> validator, IBaseQueryRepository<AppointmentQueue> iAppointmentQueue)
        {
            _validator = validator;
            _iAppointmentQueue = iAppointmentQueue;
        }

        private async Task<GetAppointmentQueueResponse> GetAppointmentQueueAsync(GetAppointmentQueueRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var appointmentQueue = await _iAppointmentQueue.GetAsync(request.Id);
            if (appointmentQueue == null)
            {
                throw new KeyNotFoundException($"Appointment queue with Id {request.Id} not found.");
            }

            return new GetAppointmentQueueResponse
            {
                Id = appointmentQueue.Id,
                AppointmentId = appointmentQueue.AppointmentId,
                QueueNumber = appointmentQueue.QueueNumber,
                EstimatedTime = appointmentQueue.EstimatedTime,
                Status = appointmentQueue.Status
            };
        }

        public async Task<GetAppointmentQueueResponse> Handle(GetAppointmentQueueRequest request, CancellationToken cancellationToken)
        {
            return await GetAppointmentQueueAsync(request);
        }
    }
}