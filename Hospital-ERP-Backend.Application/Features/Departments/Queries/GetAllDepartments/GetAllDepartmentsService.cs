using FluentValidation;
using Hospital_ERP_Backend.Application.Features.DrugInteractions.Queries.GetAllDrugInteractions;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Application.Features.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsService : IRequestHandler<GetAllDepartmentsRequest, IEnumerable<GetAllDepartmentsResponse>>
    {
        private readonly IBaseQueryRepository<Department> _repository;
        private readonly IValidator<GetAllDepartmentsRequest> _validator;

        public GetAllDepartmentsService(IBaseQueryRepository<Department> repository, IValidator<GetAllDepartmentsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }


        public async Task<IEnumerable<GetAllDepartmentsResponse>> Handle(GetAllDepartmentsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllDepartmentsAsync(request);
        }

        private async Task<IEnumerable<GetAllDepartmentsResponse>> GetAllDepartmentsAsync(GetAllDepartmentsRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            IEnumerable<Department> departments = await _repository.GetAllAsync(request.Page);

            if (departments == null || !departments.Any())
            {
                throw new KeyNotFoundException($"No Departments found on page {request.Page}.");
            }

            return departments.Select(x => new GetAllDepartmentsResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description= x.Description
            });
        }
    }
}
