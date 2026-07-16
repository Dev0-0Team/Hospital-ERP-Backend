using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AppointmentQueues.Queries.GetAllAppointmentQueues
{
    public class GetAllAppointmentQueuesService : IRequestHandler<GetAllAppointmentQueuesRequest, IEnumerable<GetAllAppointmentQueuesResponse>>
    {
        private readonly IValidator<GetAllAppointmentQueuesRequest> _validator;
        private readonly IBaseQueryRepository<AppointmentQueue> _iAppointmentQueue;

        public GetAllAppointmentQueuesService(IValidator<GetAllAppointmentQueuesRequest> validator, IBaseQueryRepository<AppointmentQueue> iAppointmentQueue)
        {
            _validator = validator;
            _iAppointmentQueue = iAppointmentQueue;
        }

        private async Task<IEnumerable<GetAllAppointmentQueuesResponse>> GetAllAppointmentQueuesAsync(GetAllAppointmentQueuesRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var appointmentQueues = await _iAppointmentQueue.GetAllAsync(request.Page);
            if (appointmentQueues == null || appointmentQueues.Count() == 0)
            {
                throw new KeyNotFoundException($"No appointment queues found on page {request.Page}.");
            }

            return appointmentQueues.Select(q => new GetAllAppointmentQueuesResponse
            {
                Id = q.Id,
                AppointmentId = q.AppointmentId,
                QueueNumber = q.QueueNumber,
                EstimatedTime = q.EstimatedTime,
                Status = q.Status
            });
        }

        public async Task<IEnumerable<GetAllAppointmentQueuesResponse>> Handle(GetAllAppointmentQueuesRequest request, CancellationToken cancellationToken)
        {
            return await GetAllAppointmentQueuesAsync(request);
        }
    }
}