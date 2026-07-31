using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Commands.CreateAppointment
{
    internal class CreateAppointmentService : IRequestHandler<CreateAppointmentRequest, CreateAppointmentResponse>
    {
        private readonly IValidator<CreateAppointmentRequest> _validator;
        private readonly IBaseCommandRepository<Appointment> _iAppointment;

        public CreateAppointmentService(IValidator<CreateAppointmentRequest> validator, IBaseCommandRepository<Appointment> iAppointment)
        {
            _validator = validator;
            _iAppointment = iAppointment;
        }

        public async Task<CreateAppointmentResponse> Handle(CreateAppointmentRequest request, CancellationToken cancellationToken)
        {
            return await CreateAppointmentAsync(request);
        }

        private async Task<CreateAppointmentResponse> CreateAppointmentAsync(CreateAppointmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Appointment appointment = new Appointment
            {
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                PriorityId = request.PriorityId,
                AppointmentDate = request.AppointmentDate,
                Status = request.Status,
                Type = request.Type
            };

            Appointment? result = await _iAppointment.CreateAsync(appointment);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to create appointment.");
            }

            return new CreateAppointmentResponse
            {
                Id = result.Id,
                PatientId = result.PatientId,
                DoctorId = result.DoctorId,
                PriorityId = result.PriorityId,
                AppointmentDate = result.AppointmentDate,
                Status = result.Status,
                Type = result.Type
            };
        }
    }
}