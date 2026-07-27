using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Departments.Queries.GetDepartment
{
    internal class GetDepartmentService : IRequestHandler<GetDepartmentRequest, GetDepartmentResponse>
    {
        private readonly IBaseQueryRepository<Department> _repository;

        private readonly IValidator<GetDepartmentRequest> _validator;

        public GetDepartmentService(IBaseQueryRepository<Department> repository,
            IValidator<GetDepartmentRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetDepartmentResponse> Handle(GetDepartmentRequest request,
            CancellationToken cancellationToken)
        {
            return await GetDepartmentAsync(request);
        }

        private async Task<GetDepartmentResponse> GetDepartmentAsync(GetDepartmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Department? department = await _repository.GetAsync(request.Id);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with Id {request.Id} not found.");
            }

            return new GetDepartmentResponse
            {
                Id = department.Id,
                Name = department.Name,
                Description= department.Description
            };
        }
    }
}
