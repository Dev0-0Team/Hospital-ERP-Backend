using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Appointments.Queries.GetAllAppointments
{
    internal class GetAllAppointmentsService : IRequestHandler<GetAllAppointmentsRequest, IEnumerable<GetAllAppointmentsResponse>>
    {
        private readonly IValidator<GetAllAppointmentsRequest> _validator;
        private readonly IBaseQueryRepository<Appointment> _iAppointment;

        public GetAllAppointmentsService(IValidator<GetAllAppointmentsRequest> getAllAppointmentsRequest, IBaseQueryRepository<Appointment> iAppointment)
        {
            _validator = getAllAppointmentsRequest;
            _iAppointment = iAppointment;
        }

        public async Task<IEnumerable<GetAllAppointmentsResponse>> Handle(GetAllAppointmentsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllAppointmentsAsync(request);
        }

        private async Task<IEnumerable<GetAllAppointmentsResponse>> GetAllAppointmentsAsync(GetAllAppointmentsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }
            var appointments = await _iAppointment.GetAllAsync(request.Page);
            if (appointments == null || appointments.Count() == 0)
            {
                throw new KeyNotFoundException($"No appointments found on page {request.Page}.");
            }

            return appointments.Select(a => new GetAllAppointmentsResponse
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                PriorityId = a.PriorityId,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status,
                Type = a.Type,
            });
        }
    }
}