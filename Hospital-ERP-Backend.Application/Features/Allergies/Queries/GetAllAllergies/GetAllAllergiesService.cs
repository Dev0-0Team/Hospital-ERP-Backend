using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Queries.GetAllAllergies
{
    public class GetAllAllergiesService :
        IRequestHandler<GetAllAllergiesRequest,
        IEnumerable<GetAllAllergiesResponse>>
    {
        private readonly IBaseQueryRepository<Allergy> _repository;

        private readonly IValidator<GetAllAllergiesRequest> _validator;

        public GetAllAllergiesService(
            IBaseQueryRepository<Allergy> repository,
            IValidator<GetAllAllergiesRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllAllergiesResponse>> Handle(
            GetAllAllergiesRequest request,
            CancellationToken cancellationToken)
        {
            return await GetAllAllergiesAsync(request);
        }

        private async Task<IEnumerable<GetAllAllergiesResponse>>
            GetAllAllergiesAsync(
            GetAllAllergiesRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            IEnumerable<Allergy> allergies =
                await _repository.GetAllAsync(request.Page);

            if (allergies == null || !allergies.Any())
            {
                throw new KeyNotFoundException(
                    $"No allergies found on page {request.Page}.");
            }

            return allergies.Select(x => new GetAllAllergiesResponse
            {
                Id = x.Id,
                PatientId = x.PatientId,
                AllergyName = x.AllergyName,
                Severity = x.Severity
            });
        }
    }
}