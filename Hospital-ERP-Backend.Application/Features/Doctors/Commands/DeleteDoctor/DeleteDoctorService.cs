using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.DeleteDoctor
{
    internal class DeleteDoctorService : IRequestHandler<DeleteDoctorRequest, bool>
    {
        private readonly IBaseCommandRepository<Doctor> _commandRepository;
        private readonly IBaseQueryRepository<Doctor> _queryRepository;
        private readonly IValidator<DeleteDoctorRequest> _validator;

        public DeleteDoctorService(
            IBaseCommandRepository<Doctor> commandRepository,
            IBaseQueryRepository<Doctor> queryRepository,
            IValidator<DeleteDoctorRequest> validator)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteDoctorRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Doctor? doctor = await _queryRepository.GetAsync(request.Id);

            if (doctor == null)
            {
                throw new KeyNotFoundException($"Doctor with Id {request.Id} not found.");
            }

            bool result = await _commandRepository.DeleteAsync(doctor.Id);

            if (!result)
            {
                throw new InvalidOperationException("Failed to delete doctor.");
            }

            return result;
        }
    }
}