using FluentValidation;
using FluentValidation.Results;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.SurgeriesHistories.Queries.GetAllSurgeriesHistories
{
    internal class GetAllSurgeriesHistoriesService : IRequestHandler<GetAllSurgeriesHistoriesRequest, IEnumerable<GetAllSurgeriesHistoriesResponse>>
    {
         private readonly IBaseQueryRepository<SurgeriesHistory> _repository;
        private readonly IValidator<GetAllSurgeriesHistoriesRequest> _validator;

        public GetAllSurgeriesHistoriesService(IBaseQueryRepository<SurgeriesHistory> repository, IValidator<GetAllSurgeriesHistoriesRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllSurgeriesHistoriesResponse>> Handle(GetAllSurgeriesHistoriesRequest request, CancellationToken cancellationToken)
        {
            return await GetAllSpecializationsAsync(request);
        }

        private async Task<IEnumerable<GetAllSurgeriesHistoriesResponse>> GetAllSpecializationsAsync(GetAllSurgeriesHistoriesRequest request)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Invalid request: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
            }

            IEnumerable<SurgeriesHistory> list = await _repository.GetAllAsync(request.Page);
            if (list == null || list.Count() == 0)
            {
                throw new KeyNotFoundException($"No Surgeries History found on page {request.Page}.");
            }

            return list.Select(r => new GetAllSurgeriesHistoriesResponse
            {
                Id = r.Id,
                SurgeryName = r.SurgeryName,
                SurgeryDate = r.SurgeryDate,
                PatientId = r.PatientId
            });
        }
    }
}