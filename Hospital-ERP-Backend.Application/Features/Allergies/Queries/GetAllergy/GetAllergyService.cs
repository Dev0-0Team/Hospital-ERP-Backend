using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Queries.GetAllergy
{
    public class GetAllergyService :
        IRequestHandler<GetAllergyRequest, GetAllergyResponse>
    {
        private readonly IBaseQueryRepository<Allergy> _repository;

        private readonly IValidator<GetAllergyRequest> _validator;

        public GetAllergyService(
            IBaseQueryRepository<Allergy> repository,
            IValidator<GetAllergyRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetAllergyResponse> Handle(
            GetAllergyRequest request,
            CancellationToken cancellationToken)
        {
            return await GetAllergyAsync(request);
        }

        private async Task<GetAllergyResponse> GetAllergyAsync(
            GetAllergyRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            Allergy? allergy =
                await _repository.GetAsync(request.Id);

            if (allergy == null)
            {
                throw new KeyNotFoundException(
                    $"Allergy with Id {request.Id} not found.");
            }

            return new GetAllergyResponse
            {
                Id = allergy.Id,
                PatientId = allergy.PatientId,
                AllergyName = allergy.AllergyName,
                Severity = allergy.Severity
            };
        }
    }
}