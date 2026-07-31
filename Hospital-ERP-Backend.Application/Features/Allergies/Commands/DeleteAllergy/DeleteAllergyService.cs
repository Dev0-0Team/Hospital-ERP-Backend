using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Commands.DeleteAllergy
{
    internal class DeleteAllergyService :
        IRequestHandler<DeleteAllergyRequest, bool>
    {
        private readonly IBaseCommandRepository<Allergy> _repository;

        private readonly IBaseQueryRepository<Allergy> _queryRepository;

        private readonly IValidator<DeleteAllergyRequest> _validator;

        public DeleteAllergyService(
            IBaseCommandRepository<Allergy> repository,
            IBaseQueryRepository<Allergy> queryRepository,
            IValidator<DeleteAllergyRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(
            DeleteAllergyRequest request,
            CancellationToken cancellationToken)
        {
            return await DeleteAllergyAsync(request);
        }

        private async Task<bool> DeleteAllergyAsync(
            DeleteAllergyRequest request)
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
                await _queryRepository.GetAsync(request.Id);

            if (allergy == null)
            {
                throw new KeyNotFoundException(
                    $"Allergy with Id {request.Id} not found.");
            }

            bool isDeleted =
                await _repository.DeleteAsync(allergy.Id);

            if (!isDeleted)
            {
                throw new InvalidOperationException(
                    $"Failed to delete Allergy with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}