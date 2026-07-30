using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.UpdateDoctorSchedule
{
    internal class UpdateDoctorScheduleService
        : IRequestHandler<UpdateDoctorScheduleRequest, UpdateDoctorScheduleResponse>
    {
        private readonly IBaseCommandRepository<DoctorSchedule> _repository;
        private readonly IBaseCommandRepository<Doctor> _doctorRepository;
        private readonly IValidator<UpdateDoctorScheduleRequest> _validator;

        public UpdateDoctorScheduleService(
            IBaseCommandRepository<DoctorSchedule> repository,
            IBaseCommandRepository<Doctor> doctorRepository,
            IValidator<UpdateDoctorScheduleRequest> validator)
        {
            _repository = repository;
            _doctorRepository = doctorRepository;
            _validator = validator;
        }

        public async Task<UpdateDoctorScheduleResponse> Handle(UpdateDoctorScheduleRequest request, CancellationToken cancellationToken)
        {
            return await UpdateDoctorScheduleAsync(request);
        }

        private async Task<UpdateDoctorScheduleResponse> UpdateDoctorScheduleAsync(UpdateDoctorScheduleRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool doctor = await _doctorRepository.IsExistAsync(request.DoctorId);

            if (!doctor)
            {
                throw new KeyNotFoundException($"Doctor with Id {request.DoctorId} not found.");
            }

            DoctorSchedule? schedule = await _repository.FindAsync(request.Id);

            if (schedule == null)
            {
                throw new KeyNotFoundException($"Doctor Schedule with Id {request.Id} not found.");
            }

            schedule.DoctorId = request.DoctorId;
            schedule.DayOfWeek = request.DayOfWeek.ToString();
            schedule.StartTime = request.StartTime;
            schedule.EndTime = request.EndTime;
            schedule.UpdatedAt = DateTime.UtcNow;

            DoctorSchedule? result = await _repository.UpdateAsync(schedule);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Doctor Schedule.");
            }

            return new UpdateDoctorScheduleResponse
            {
                Id = result.Id,
                DoctorId = result.DoctorId,
                DayOfWeek = result.DayOfWeek,
                StartTime = result.StartTime,
                EndTime = result.EndTime
            };
        }
    }
}