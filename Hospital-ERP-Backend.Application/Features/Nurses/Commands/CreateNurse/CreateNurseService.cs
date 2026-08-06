using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.CreateNurse
{
    internal class CreateNurseService : IRequestHandler<CreateNurseRequest, CreateNurseResponse>
    {
        private readonly IBaseCommandRepository<Person> _personRepository;
        private readonly IBaseCommandRepository<Department> _departmentRepository;
        private readonly IBaseCommandRepository<Nurse> _repository;
        private readonly IValidator<CreateNurseRequest> _validator;

        public CreateNurseService(IBaseCommandRepository<Person> personRepository,
            IBaseCommandRepository<Department> departmentRepository,
            IBaseCommandRepository<Nurse> repository, IValidator<CreateNurseRequest> validator)
        {
            _personRepository = personRepository;
            _departmentRepository = departmentRepository;
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateNurseResponse> Handle(CreateNurseRequest request, CancellationToken cancellationToken)
        {
            return await CreateNurseAsync(request);
        }

        public async Task<CreateNurseResponse> CreateNurseAsync(CreateNurseRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException( string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool person =await _personRepository.IsExistAsync(request.PersonId);

            if (!person)
            {
                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }

            bool department = await _departmentRepository.IsExistAsync(request.DepartmentId);

            if (!department)
            {
                throw new KeyNotFoundException($"Department with Id {request.DepartmentId} not found.");
            }


            Nurse nurse = new()
            {
                PersonId = request.PersonId,
                DepartmentId = request.DepartmentId
            };

            Nurse? result =await _repository.CreateAsync(nurse);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Nurse.");
            }

            return new CreateNurseResponse
            {
                Id = result.Id,
                PersonId = result.PersonId,
                DepartmentId = result.DepartmentId
            };
        }
    }
}
