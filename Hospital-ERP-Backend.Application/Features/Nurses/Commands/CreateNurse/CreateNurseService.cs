using FluentValidation;
using Hospital_ERP_Backend.Application.Features.Doctors.Commands.CreateDoctor;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.CreateNurse
{
    public class CreateNurseService : IRequestHandler<CreateNurseRequest, CreateNurseResponse>
    {
        private readonly IBaseQueryRepository<Person> _personRepository;
        private readonly IBaseQueryRepository<Department> _departmentRepository;
        private readonly IBaseCommandRepository<Nurse> _repository;
        private readonly IValidator<CreateNurseRequest> _validator;

        public CreateNurseService(IBaseQueryRepository<Person> personRepository,
            IBaseQueryRepository<Department> departmentRepository,
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

            Person? person =await _personRepository.GetAsync(request.PersonId);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.PersonId} not found.");
            }

            Department? department = await _departmentRepository.GetAsync(request.DepartmentId);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with Id {request.DepartmentId} not found.");
            }


            Nurse nurse = new()
            {
                PersonId = request.PersonId,
                DepartmentId = request.DepartmentId,
                CreatedAt = DateTime.UtcNow
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
