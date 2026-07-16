

using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Nurses.Commands.CreateNurse;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.UpdateNurse
{
    public class UpdateNurseService : IRequestHandler<UpdateNurseRequest, UpdateNurseResponse>
    {
        private readonly IBaseQueryRepository<Person> _personRepository;
        private readonly IBaseQueryRepository<Department> _departmentRepository;
        private readonly IBaseQueryRepository<Nurse> _nurseRepository;
        private readonly IBaseCommandRepository<Nurse> _repository;
        private readonly IValidator<UpdateNurseRequest> _validator;

        public UpdateNurseService(IBaseQueryRepository<Person> personRepository,
            IBaseQueryRepository<Department> departmentRepository, IBaseQueryRepository<Nurse> nurseRepository,
            IBaseCommandRepository<Nurse> repository, IValidator<UpdateNurseRequest> validator)
        {
            _personRepository = personRepository;
            _departmentRepository = departmentRepository;
            _nurseRepository = nurseRepository;
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

            Nurse? nurse = await _nurseRepository.GetAsync(request.Id);
            if(nurse == null)
            {
                throw new KeyNotFoundException($"Nurse with Id {request.Id} not found.");
            }

            Person? person = await _personRepository.GetAsync(request.PersonId);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }

            Department? department = await _departmentRepository.GetAsync(request.DepartmentId);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with Id {request.DepartmentId} not found.");
            }

            nurse.DepartmentId = department.Id;
            nurse.PersonId = person.Id;
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
