using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.UpdateNurse
{
    internal class UpdateNurseService : IRequestHandler<UpdateNurseRequest, UpdateNurseResponse>
    {
        private readonly IBaseCommandRepository<Person> _personRepository;
        private readonly IBaseCommandRepository<Department> _departmentRepository;
        private readonly IBaseCommandRepository<Nurse> _repository;
        private readonly IValidator<UpdateNurseRequest> _validator;

        public UpdateNurseService(IBaseCommandRepository<Person> personRepository,
            IBaseCommandRepository<Department> departmentRepository,
            IBaseCommandRepository<Nurse> repository, IValidator<UpdateNurseRequest> validator)
        {
            _personRepository = personRepository;
            _departmentRepository = departmentRepository;
            _repository = repository;
            _validator = validator;
        }

        public async Task<UpdateNurseResponse> Handle(UpdateNurseRequest request, CancellationToken cancellationToken)
        {
            return await UpdateNurseAsync(request);
        }

        public async Task<UpdateNurseResponse> UpdateNurseAsync(UpdateNurseRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Nurse? nurse = await _repository.FindAsync(request.Id);
            if(nurse == null)
            {
                throw new KeyNotFoundException($"Nurse with Id {request.Id} not found.");
            }

            bool person = await _personRepository.IsExistAsync(request.PersonId);

            if (!person)
            {
                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }

            bool department = await _departmentRepository.IsExistAsync(request.DepartmentId);

            if (!department)
            {
                throw new KeyNotFoundException($"Department with Id {request.DepartmentId} not found.");
            }

            nurse.DepartmentId = request.Id;
            nurse.PersonId = request.Id;
            nurse.UpdatedAt = DateTime.UtcNow;

            Nurse? result = await _repository.UpdateAsync(nurse);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to Update Nurse.");
            }

            return new UpdateNurseResponse
            {
                Id = result.Id,
                PersonId = result.PersonId,
                DepartmentId = result.DepartmentId
            };
        }
    }
}
