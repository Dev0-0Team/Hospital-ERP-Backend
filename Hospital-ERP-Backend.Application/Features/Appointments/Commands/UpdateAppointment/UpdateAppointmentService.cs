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
        private readonly IBaseCommandRepository<QueuePriority> _iPriority;
        private readonly IBaseCommandRepository<Doctor> _iDoctor;

        public UpdateAppointmentService(IValidator<UpdateAppointmentRequest> validator, IBaseCommandRepository<Appointment> iAppointment, IBaseCommandRepository<Doctor> iDoctor, IBaseCommandRepository<QueuePriority> iQueuePriority)
        {
            _validator = validator;
            _iAppointment = iAppointment;
            _iPriority = iQueuePriority;
            _iDoctor = iDoctor;
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

            bool isDoctorExist = await _iDoctor.IsExistAsync(request.DoctorId);
            if (!isDoctorExist)
            {
                throw new KeyNotFoundException($"Doctor with Id {request.DoctorId} not found.");
            }
            
            bool isPriorityExist = await _iPriority.IsExistAsync(request.PriorityId);
            if (!isDoctorExist)
            {
                throw new KeyNotFoundException($"Queue Priority with Id {request.PriorityId} not found.");
            }

            Appointment? existingAppointment = await _iAppointment.FindAsync(request.Id);
            if (existingAppointment == null)
            {
                throw new KeyNotFoundException($"Appointment with Id {request.Id} not found.");
            }

            existingAppointment.PatientId = request.PatientId;
            existingAppointment.DoctorId = request.DoctorId;
            existingAppointment.PriorityId = request.PriorityId;
            existingAppointment.AppointmentDate = request.AppointmentDate;
            existingAppointment.Status = request.Status.ToString();
            existingAppointment.Type = request.Type.ToString();
            existingAppointment.UpdatedAt = DateTime.UtcNow;

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