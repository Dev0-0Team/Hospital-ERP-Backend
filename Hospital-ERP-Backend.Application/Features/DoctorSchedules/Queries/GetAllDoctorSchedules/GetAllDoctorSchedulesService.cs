using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Queries.GetAllDoctorSchedules
{
    public class GetAllDoctorSchedulesService
        : IRequestHandler<GetAllDoctorSchedulesRequest,
            IEnumerable<GetAllDoctorSchedulesResponse>>
    {
        private readonly IBaseQueryRepository<DoctorSchedule> _repository;

        private readonly IValidator<GetAllDoctorSchedulesRequest> _validator;

        public GetAllDoctorSchedulesService(
            IBaseQueryRepository<DoctorSchedule> repository,
            IValidator<GetAllDoctorSchedulesRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllDoctorSchedulesResponse>> Handle(GetAllDoctorSchedulesRequest request, CancellationToken cancellationToken)
        {
            return await GetAllDoctorSchedulesAsync(request);
        }

        private async Task<IEnumerable<GetAllDoctorSchedulesResponse>> GetAllDoctorSchedulesAsync(GetAllDoctorSchedulesRequest request)
        {
            var validationResult =
              await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            IEnumerable<DoctorSchedule> schedules =
                await _repository.GetAllAsync(request.Page);

            if (schedules == null || !schedules.Any())
            {
                throw new KeyNotFoundException(
                    $"No Doctor Schedules found on page {request.Page}");
            }

            return schedules.Select(x => new GetAllDoctorSchedulesResponse
            {
                Id = x.Id,
                DoctorId = x.DoctorId,
                DayOfWeek = x.DayOfWeek,
                StartTime = x.StartTime,
                EndTime = x.EndTime
            });
        }
    }
}