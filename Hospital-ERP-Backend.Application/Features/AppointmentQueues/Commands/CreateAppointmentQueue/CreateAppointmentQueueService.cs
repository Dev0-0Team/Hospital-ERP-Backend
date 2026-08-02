using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Commands.CreateAppointmentQueue
{
    internal class CreateAppointmentQueueService : IRequestHandler<CreateAppointmentQueueRequest, CreateAppointmentQueueResponse>
    {
        private readonly IValidator<CreateAppointmentQueueRequest> _validator;
        private readonly IBaseCommandRepository<AppointmentQueue> _iAppointmentQueue;
        private readonly IBaseCommandRepository<Appointment> _iAppointment;

        public CreateAppointmentQueueService(IValidator<CreateAppointmentQueueRequest> validator, IBaseCommandRepository<AppointmentQueue> iAppointmentQueue, IBaseCommandRepository<Appointment> iAppointment)
        {
            _validator = validator;
            _iAppointmentQueue = iAppointmentQueue;
            _iAppointment = iAppointment;
        }

        public async Task<CreateAppointmentQueueResponse> Handle(CreateAppointmentQueueRequest request, CancellationToken cancellationToken)
        {
            return await CreateAppointmentQueueAsync(request);
        }

        private async Task<CreateAppointmentQueueResponse> CreateAppointmentQueueAsync(CreateAppointmentQueueRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            bool isAppointmentExist = await _iAppointment.IsExistAsync(request.AppointmentId);
            if (!isAppointmentExist)
            {
                throw new KeyNotFoundException($"Appointment with Id {request.AppointmentId} not found.");
            }

            AppointmentQueue appointmentQueue = new AppointmentQueue
            {
                AppointmentId = request.AppointmentId,
                QueueNumber = request.QueueNumber,
                EstimatedTime = request.EstimatedTime,
                Status = request.Status.ToString()
            };

            AppointmentQueue? result = await _iAppointmentQueue.CreateAsync(appointmentQueue);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create appointment queue.");
            }

            return new CreateAppointmentQueueResponse
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