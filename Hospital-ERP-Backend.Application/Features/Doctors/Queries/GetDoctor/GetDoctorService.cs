using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetDoctor
{
    internal class GetDoctorService : IRequestHandler<GetDoctorRequest, GetDoctorResponse>
    {
        private readonly IBaseQueryRepository<Doctor> _repository;

        private readonly IValidator<GetDoctorRequest> _validator;

        public GetDoctorService(
            IBaseQueryRepository<Doctor> repository,
            IValidator<GetDoctorRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetDoctorResponse> Handle(GetDoctorRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Doctor? doctor = await _repository.GetAsync(request.Id);

            if (doctor == null)
            {
                throw new KeyNotFoundException($"Doctor with Id {request.Id} not found.");
            }

            return new GetDoctorResponse
            {
                Id = doctor.Id,
                PersonId = doctor.PersonId,
                DepartmentId = doctor.DepartmentId,
                SpecializationId = doctor.SpecializationId,
                LicenseNumber = doctor.LicenseNumber
            };
        }
    }
}