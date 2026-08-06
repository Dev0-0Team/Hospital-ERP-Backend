using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Commands.DeleteAppointment
{
    internal class DeleteAppointmentService : IRequestHandler<DeleteAppointmentRequest, bool>
    {
        private readonly IValidator<DeleteAppointmentRequest> _validator;
        private readonly IBaseCommandRepository<Appointment> _iAppointment;

        public DeleteAppointmentService(IValidator<DeleteAppointmentRequest> validator, IBaseCommandRepository<Appointment> iAppointment)
        {
            _validator = validator;
            _iAppointment = iAppointment;
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

            bool appointment = await _iAppointment.IsExistAsync(request.Id);
            if (!appointment)
            {
                throw new KeyNotFoundException($"Appointment with Id {request.Id} not found.");
            }

            // Soft delete: BaseCommandRepository.DeleteAsync flags IsDeleted/DeletedAt
            // instead of physically removing the row from the table.
            var isDeleted = await _iAppointment.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete appointment with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}