using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.DeleteDoctorSchedule
{
    public class DeleteDoctorScheduleService
        : IRequestHandler<DeleteDoctorScheduleRequest, bool>
    {
        private readonly IBaseCommandRepository<DoctorSchedule> _repository;
        private readonly IBaseQueryRepository<DoctorSchedule> _queryRepository;
        private readonly IValidator<DeleteDoctorScheduleRequest> _validator;

        public DeleteDoctorScheduleService(
            IBaseCommandRepository<DoctorSchedule> repository,
            IBaseQueryRepository<DoctorSchedule> queryRepository,
            IValidator<DeleteDoctorScheduleRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(
            DeleteDoctorScheduleRequest request,
            CancellationToken cancellationToken)
        {
            return await DeleteDoctorScheduleAsync(request);
        }

        private async Task<bool> DeleteDoctorScheduleAsync(
            DeleteDoctorScheduleRequest request)
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
                await _queryRepository.GetAsync(request.Id);

            if (schedule == null)
            {
                throw new KeyNotFoundException(
                    $"Doctor Schedule with Id {request.Id} not found.");
            }

            return await _repository.DeleteAsync(request.Id);
        }
    }
}