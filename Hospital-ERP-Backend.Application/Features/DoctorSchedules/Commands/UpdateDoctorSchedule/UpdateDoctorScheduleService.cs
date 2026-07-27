using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.UpdateDoctorSchedule
{
    public class UpdateDoctorScheduleService
        : IRequestHandler<UpdateDoctorScheduleRequest, UpdateDoctorScheduleResponse>
    {
        private readonly IBaseCommandRepository<DoctorSchedule> _repository;
        private readonly IBaseQueryRepository<DoctorSchedule> _queryRepository;
        private readonly IBaseQueryRepository<Doctor> _doctorRepository;
        private readonly IValidator<UpdateDoctorScheduleRequest> _validator;

        public UpdateDoctorScheduleService(
            IBaseCommandRepository<DoctorSchedule> repository,
            IBaseQueryRepository<DoctorSchedule> queryRepository,
            IBaseQueryRepository<Doctor> doctorRepository,
            IValidator<UpdateDoctorScheduleRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _doctorRepository = doctorRepository;
            _validator = validator;
        }

        public async Task<UpdateDoctorScheduleResponse> Handle(
            UpdateDoctorScheduleRequest request,
            CancellationToken cancellationToken)
        {
            return await UpdateDoctorScheduleAsync(request);
        }

        private async Task<UpdateDoctorScheduleResponse> UpdateDoctorScheduleAsync(
            UpdateDoctorScheduleRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Doctor? doctor =
                await _doctorRepository.GetAsync(request.DoctorId);

            if (doctor == null)
            {
                throw new KeyNotFoundException(
                    $"Doctor with Id {request.DoctorId} not found.");
            }

            DoctorSchedule? schedule =
                await _queryRepository.GetAsync(request.Id);

            if (schedule == null)
            {
                throw new KeyNotFoundException(
                    $"Doctor Schedule with Id {request.Id} not found.");
            }

            schedule.DoctorId = request.DoctorId;
            schedule.DayOfWeek = request.DayOfWeek.ToString();
            schedule.StartTime = request.StartTime;
            schedule.EndTime = request.EndTime;
            schedule.UpdatedAt = DateTime.UtcNow;

            DoctorSchedule? result =
                await _repository.UpdateAsync(schedule);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to update Doctor Schedule.");
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