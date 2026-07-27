using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.CreateDoctorSchedule
{
    internal class CreateDoctorScheduleService
        : IRequestHandler<CreateDoctorScheduleRequest,
            CreateDoctorScheduleResponse>
    {
        private readonly IBaseCommandRepository<DoctorSchedule> _repository;

        private readonly IBaseQueryRepository<Doctor> _doctorRepository;

        private readonly IValidator<CreateDoctorScheduleRequest> _validator;

        public CreateDoctorScheduleService(
            IBaseCommandRepository<DoctorSchedule> repository,
            IBaseQueryRepository<Doctor> doctorRepository,
            IValidator<CreateDoctorScheduleRequest> validator)
        {
            _repository = repository;
            _doctorRepository = doctorRepository;
            _validator = validator;
        }

        public async Task<CreateDoctorScheduleResponse> Handle(CreateDoctorScheduleRequest request, CancellationToken cancellationToken)
        {
            return await CreateDoctorScheduleAsync(request);
        }

        private async Task<CreateDoctorScheduleResponse> CreateDoctorScheduleAsync(CreateDoctorScheduleRequest request)
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

            DoctorSchedule schedule = new()
            {
                DoctorId = request.DoctorId,
                DayOfWeek = request.DayOfWeek.ToString(),
                StartTime = request.StartTime,
                EndTime = request.EndTime
            };

            DoctorSchedule? result =
                await _repository.CreateAsync(schedule);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to create Doctor Schedule.");
            }

            return new CreateDoctorScheduleResponse
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