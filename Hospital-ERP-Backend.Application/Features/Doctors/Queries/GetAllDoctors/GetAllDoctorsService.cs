using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetAllDoctors
{
    public class GetAllDoctorsService : IRequestHandler<GetAllDoctorsRequest, IEnumerable<GetAllDoctorsResponse>>
    {
        private readonly IBaseQueryRepository<Doctor> _repository;

        private readonly IValidator<GetAllDoctorsRequest> _validator;

        public GetAllDoctorsService(
            IBaseQueryRepository<Doctor> repository,
            IValidator<GetAllDoctorsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllDoctorsResponse>> Handle(GetAllDoctorsRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var doctors = await _repository.GetAllAsync(request.Page);

            if (doctors == null || !doctors.Any())
            {
                throw new KeyNotFoundException($"No Doctors found on page {request.Page}");
            }

            return doctors.Select(x => new GetAllDoctorsResponse
            {
                Id = x.Id,
                PersonId = x.PersonId,
                DepartmentId = x.DepartmentId,
                SpecializationId = x.SpecializationId,
                LicenseNumber = x.LicenseNumber
            });
        }
    }
}