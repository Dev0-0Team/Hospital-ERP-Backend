using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Commands.UpdateAppointment
{
    internal class UpdateAppointmentService : IRequestHandler<UpdateAppointmentRequest, UpdateAppointmentResponse>
    {
        private readonly IValidator<UpdateAppointmentRequest> _validator;
        private readonly IBaseCommandRepository<Appointment> _iAppointment;
        private readonly IBaseQueryRepository<Appointment> _iAppointmentQuery;

        public UpdateAppointmentService(IValidator<UpdateAppointmentRequest> validator, IBaseCommandRepository<Appointment> iAppointment, IBaseQueryRepository<Appointment> iAppointmentQuery)
        {
            _validator = validator;
            _iAppointment = iAppointment;
            _iAppointmentQuery = iAppointmentQuery;
        }

        public async Task<UpdateAppointmentResponse> Handle(UpdateAppointmentRequest request, CancellationToken cancellationToken)
        {
            return await UpdateAppointmentAsync(request);
        }

        private async Task<UpdateAppointmentResponse> UpdateAppointmentAsync(UpdateAppointmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            Appointment? existingAppointment = await _iAppointmentQuery.GetAsync(request.Id);
            if (existingAppointment == null)
            {
                throw new KeyNotFoundException($"Appointment with Id {request.Id} not found.");
            }

            existingAppointment.PatientId = request.PatientId;
            existingAppointment.DoctorId = request.DoctorId;
            existingAppointment.PriorityId = request.PriorityId;
            existingAppointment.AppointmentDate = request.AppointmentDate;
            existingAppointment.Status = request.Status;
            existingAppointment.Type = request.Type;
            existingAppointment.UpdatedAt = DateTime.Now;

            Appointment? result = await _iAppointment.UpdateAsync(existingAppointment);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to update appointment.");
            }

            return new UpdateAppointmentResponse
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