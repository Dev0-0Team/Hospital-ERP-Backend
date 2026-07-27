using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Queries.GetDoctorSchedule
{
    internal class GetDoctorScheduleService
        : IRequestHandler<GetDoctorScheduleRequest,
            GetDoctorScheduleResponse>
    {
        private readonly IBaseQueryRepository<DoctorSchedule> _repository;

        private readonly IValidator<GetDoctorScheduleRequest> _validator;

        public GetDoctorScheduleService(
            IBaseQueryRepository<DoctorSchedule> repository,
            IValidator<GetDoctorScheduleRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetDoctorScheduleResponse> Handle(GetDoctorScheduleRequest request, CancellationToken cancellationToken)
        {
            return await GetDoctorScheduleAsync(request);
        }

        private async Task<GetDoctorScheduleResponse> GetDoctorScheduleAsync(GetDoctorScheduleRequest request)
        {
            var validationResult =
              await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            DoctorSchedule? schedule =
                await _repository.GetAsync(request.Id);

            if (schedule == null)
            {
                throw new KeyNotFoundException(
                    $"Doctor Schedule with Id {request.Id} not found.");
            }

            return new GetDoctorScheduleResponse
            {
                Id = schedule.Id,
                DoctorId = schedule.DoctorId,
                DayOfWeek = schedule.DayOfWeek,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime
            };
        }
    }
}