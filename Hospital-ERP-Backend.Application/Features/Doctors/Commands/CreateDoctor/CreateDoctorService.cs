using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorService : IRequestHandler<CreateDoctorRequest, CreateDoctorResponse>
    {
        private readonly IBaseCommandRepository<Doctor> _repository;

        private readonly IValidator<CreateDoctorRequest> _validator;

        public CreateDoctorService(
            IBaseCommandRepository<Doctor> repository,
            IValidator<CreateDoctorRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateDoctorResponse> Handle(CreateDoctorRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Doctor doctor = new()
            {
                PersonId = request.PersonId,
                DepartmentId = request.DepartmentId,
                SpecializationId = request.SpecializationId,
                LicenseNumber = request.LicenseNumber
            };

            var result = await _repository.CreateAsync(doctor);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Doctor.");
            }

            return new CreateDoctorResponse
            {
                Id = result.Id,
                PersonId = result.PersonId,
                DepartmentId = result.DepartmentId,
                SpecializationId = result.SpecializationId,
                LicenseNumber = result.LicenseNumber
            };
        }
    }
}