using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentService : IRequestHandler<UpdateDepartmentRequest, UpdateDepartmentResponse>
    {
        private readonly IBaseCommandRepository<Department> _repository;
        private readonly IValidator<UpdateDepartmentRequest> _validator;
        private readonly IBaseQueryRepository<Department> _queryRepository;

        public UpdateDepartmentService(IBaseCommandRepository<Department> repository, IValidator<UpdateDepartmentRequest> validator, IBaseQueryRepository<Department> queryRepository)
        {
            _repository = repository;
            _validator = validator;
            _queryRepository = queryRepository;
        }

        public async Task<UpdateDepartmentResponse> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            return await UpdateDepartmentAsync(request);
        }

        private async Task<UpdateDepartmentResponse> UpdateDepartmentAsync(UpdateDepartmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Department? department = await _queryRepository.GetAsync(request.Id);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with Id {request.Id} not found.");
            }
            department.Name = request.Name;
            department.Description = request.Description;
            department.UpdatedAt = DateTime.UtcNow;

            Department? result = await _repository.UpdateAsync(department);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to update Department.");
            }

            return new UpdateDepartmentResponse
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description
            };
        }
    }
}
