using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentService : IRequestHandler<DeleteAppointmentRequest, bool>
    {
        private readonly IValidator<DeleteAppointmentRequest> _validator;
        private readonly IBaseCommandRepository<Appointment> _iAppointment;
        private readonly IBaseQueryRepository<Appointment> _iAppointmentQuery;

        public DeleteAppointmentService(IValidator<DeleteAppointmentRequest> validator, IBaseCommandRepository<Appointment> iAppointment, IBaseQueryRepository<Appointment> iAppointmentQuery)
        {
            _validator = validator;
            _iAppointment = iAppointment;
            _iAppointmentQuery = iAppointmentQuery;
        }

        public async Task<bool> Handle(DeleteAppointmentRequest request, CancellationToken cancellationToken)
        {
            return await DeleteAppointmentAsync(request);
        }

        private async Task<bool> DeleteAppointmentAsync(DeleteAppointmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            var appointment = await _iAppointmentQuery.GetAsync(request.Id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with Id {request.Id} not found.");
            }

            // Soft delete: BaseCommandRepository.DeleteAsync flags IsDeleted/DeletedAt
            // instead of physically removing the row from the table.
            var isDeleted = await _iAppointment.DeleteAsync(appointment.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete appointment with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}