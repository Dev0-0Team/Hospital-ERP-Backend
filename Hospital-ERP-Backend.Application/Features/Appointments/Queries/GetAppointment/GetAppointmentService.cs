using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAppointment
{
    internal class GetAppointmentService : IRequestHandler<GetAppointmentRequest, GetAppointmentResponse>
    {
        private readonly IValidator<GetAppointmentRequest> _validator;
        private readonly IBaseQueryRepository<Appointment> _iAppointment;

        public GetAppointmentService(IValidator<GetAppointmentRequest> validator, IBaseQueryRepository<Appointment> iAppointment)
        {
            _validator = validator;
            _iAppointment = iAppointment;
        }

        public async Task<GetAppointmentResponse> Handle(GetAppointmentRequest request, CancellationToken cancellationToken)
        {
            return await GetAppointmentAsync(request);
        }

        private async Task<GetAppointmentResponse> GetAppointmentAsync(GetAppointmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var appointment = await _iAppointment.GetAsync(request.Id);

            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with Id {request.Id} not found.");
            }

            return new GetAppointmentResponse
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                PriorityId = appointment.PriorityId,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                Type = appointment.Type
            };
        }
    }
}