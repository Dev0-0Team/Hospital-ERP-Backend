using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.DoctorSchedules.Commands.DeleteDoctorSchedule
{
    internal class DeleteDoctorScheduleService
        : IRequestHandler<DeleteDoctorScheduleRequest, bool>
    {
        private readonly IBaseCommandRepository<DoctorSchedule> _repository;
        private readonly IValidator<DeleteDoctorScheduleRequest> _validator;

        public DeleteDoctorScheduleService(
            IBaseCommandRepository<DoctorSchedule> repository,
            IValidator<DeleteDoctorScheduleRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteDoctorScheduleRequest request, CancellationToken cancellationToken)
        {
            return await DeleteDoctorScheduleAsync(request);
        }

        private async Task<bool> DeleteDoctorScheduleAsync(DeleteDoctorScheduleRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool schedule = await _repository.IsExistAsync(request.Id);

            if (!schedule)
            {
                throw new KeyNotFoundException($"Doctor Schedule with Id {request.Id} not found.");
            }

            bool isDeleted = await _repository.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete administrative staff with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}