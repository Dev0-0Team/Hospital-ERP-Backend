using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Doctors.Queries.GetDoctor;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Nurses.Queries.GetNurse
{
    public class GetNurseService : IRequestHandler<GetNurseRequest, GetNurseResponse>
    {
        private readonly IBaseQueryRepository<Nurse> _repository;

        private readonly IValidator<GetNurseRequest> _validator;

        public GetNurseService(
            IBaseQueryRepository<Nurse> repository,
            IValidator<GetNurseRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetNurseResponse> Handle(GetNurseRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Nurse? nurse = await _repository.GetAsync(request.Id);

            if (nurse == null)
            {
                throw new KeyNotFoundException($"Nurse with Id {request.Id} not found.");
            }

            return new GetNurseResponse
            {
                Id = nurse.Id,
                PersonId = nurse.PersonId,
                DepartmentId = nurse.DepartmentId
            };
        }
    }
}
