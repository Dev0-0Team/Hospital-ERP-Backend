using FluentValidation;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.CreateDrugInteraction;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentService : IRequestHandler<CreateDepartmentRequest, CreateDepartmentResponse>
    {
        private readonly IBaseCommandRepository<Department> _repository;
        private readonly IValidator<CreateDepartmentRequest> _validator;

        public CreateDepartmentService(IBaseCommandRepository<Department> repository, IValidator<CreateDepartmentRequest> validator)
        {
            _repository = repository;
            this._validator = validator;
        }

        public async Task<CreateDepartmentResponse> Handle(CreateDepartmentRequest request, CancellationToken cancellationToken)
        {
            return await CreateDepartmentAsync(request);
        }

        private async Task<CreateDepartmentResponse> CreateDepartmentAsync(CreateDepartmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Department department = new()
            {
                Name = request.Name,
                Description = request.Description,
            };

            Department? result = await _repository.CreateAsync(department);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to create Department.");
            }

            return new CreateDepartmentResponse
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description
            };
        }
    }
}
