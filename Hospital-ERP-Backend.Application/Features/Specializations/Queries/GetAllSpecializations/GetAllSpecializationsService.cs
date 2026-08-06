using FluentValidation;
using FluentValidation.Results;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Queries.GetAllSpecializations
{
    internal class GetAllSpecializationsService : IRequestHandler<GetAllSpecializationsRequest, IEnumerable<GetAllSpecializationsResponse>>
    {
        private readonly IBaseQueryRepository<Specialization> _repository;
        private readonly IValidator<GetAllSpecializationsRequest> _validator;

        public GetAllSpecializationsService(IBaseQueryRepository<Specialization> repository, IValidator<GetAllSpecializationsRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllSpecializationsResponse>> Handle(GetAllSpecializationsRequest request, CancellationToken cancellationToken)
        {
            return await GetAllSpecializationsAsync(request);
        }

        private async Task<IEnumerable<GetAllSpecializationsResponse>> GetAllSpecializationsAsync(GetAllSpecializationsRequest request)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            IEnumerable<Specialization> list = await _repository.GetAllAsync(request.Page);
            if (list == null || list.Count() == 0)
            {
                throw new KeyNotFoundException($"No specializations found on page {request.Page}.");
            }

            return list.Select(r => new GetAllSpecializationsResponse
            {
                Id = r.Id,
                Name = r.Name
            });
        }
    }
}
