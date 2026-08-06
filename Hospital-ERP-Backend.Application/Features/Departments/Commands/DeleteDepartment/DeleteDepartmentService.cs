using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Departments.Commands.DeleteDepartment
{
    internal class DeleteDepartmentService : IRequestHandler<DeleteDepartmentRequest, bool>
    {
        private IBaseCommandRepository<Department> _repository;
        private IValidator<DeleteDepartmentRequest> _validator;

        public DeleteDepartmentService(IBaseCommandRepository<Department> repository, IValidator<DeleteDepartmentRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }


        public async Task<bool> Handle(DeleteDepartmentRequest request, CancellationToken cancellationToken)
        {
            return await DeleteDepartmentAsync(request);
        }

        private async Task<bool> DeleteDepartmentAsync(DeleteDepartmentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool department = await _repository.IsExistAsync(request.Id);

            if (!department)
            {
                throw new KeyNotFoundException($"Department with Id {request.Id} not found.");
            }

            var success = await _repository.DeleteAsync(request.Id);

            if (!success)
            {
                throw new InvalidOperationException($"Failed to delete Department with Id {request.Id}.");
            }

            return success;
        }
    }
}
