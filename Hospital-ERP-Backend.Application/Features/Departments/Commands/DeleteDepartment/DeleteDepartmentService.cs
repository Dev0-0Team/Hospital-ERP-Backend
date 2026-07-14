using FluentValidation;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Commands.DeleteDrugInteraction;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentService : IRequestHandler<DeleteDepartmentRequest, bool>
    {
        private IBaseCommandRepository<Department> _repository;
        private IBaseQueryRepository<Department> _queryRepository;
        private IValidator<DeleteDepartmentRequest> _validator;

        public DeleteDepartmentService(IBaseCommandRepository<Department> repository, IBaseQueryRepository<Department> queryRepository, IValidator<DeleteDepartmentRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
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

            Department? department = await _queryRepository.GetAsync(request.Id);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with Id {request.Id} not found.");
            }

            var success = await _repository.DeleteAsync(department.Id);

            if (!success)
            {
                throw new InvalidOperationException($"Failed to delete Department with Id {request.Id}.");
            }

            return success;
        }
    }
}
