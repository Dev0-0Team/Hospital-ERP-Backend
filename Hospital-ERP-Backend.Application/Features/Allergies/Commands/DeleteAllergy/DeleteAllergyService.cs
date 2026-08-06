using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Commands.DeleteAllergy
{
    internal class DeleteAllergyService : IRequestHandler<DeleteAllergyRequest, bool>
    {
        private readonly IBaseCommandRepository<Allergy> _repository;
        private readonly IValidator<DeleteAllergyRequest> _validator;

        public DeleteAllergyService(
            IBaseCommandRepository<Allergy> repository, IValidator<DeleteAllergyRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteAllergyRequest request, CancellationToken cancellationToken)
        {
            return await DeleteAllergyAsync(request);
        }

        private async Task<bool> DeleteAllergyAsync(DeleteAllergyRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool allergy = await _repository.IsExistAsync(request.Id);

            if (!allergy)
            {
                throw new KeyNotFoundException($"Allergy with Id {request.Id} not found.");
            }

            bool isDeleted = await _repository.DeleteAsync(request.Id);

            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete Allergy with Id {request.Id}.");
            }

            return isDeleted;
        }
    }
}