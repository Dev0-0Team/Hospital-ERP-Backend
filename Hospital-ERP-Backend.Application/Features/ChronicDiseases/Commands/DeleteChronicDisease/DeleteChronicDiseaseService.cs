using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.DeleteChronicDisease
{
    internal class DeleteChronicDiseaseService
        : IRequestHandler<DeleteChronicDiseaseRequest, bool>
    {
        private readonly IBaseCommandRepository<ChronicDisease> _repository;
        private readonly IValidator<DeleteChronicDiseaseRequest> _validator;

        public DeleteChronicDiseaseService(
            IBaseCommandRepository<ChronicDisease> repository, IValidator<DeleteChronicDiseaseRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteChronicDiseaseRequest request, CancellationToken cancellationToken)
        {
            return await DeleteChronicDiseaseAsync(request);
        }

        private async Task<bool> DeleteChronicDiseaseAsync(DeleteChronicDiseaseRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            bool disease = await _repository.IsExistAsync(request.Id);

            if (!disease)
            {
                throw new KeyNotFoundException($"Chronic Disease with Id {request.Id} not found.");
            }
            
            bool isDeleted = await _repository.DeleteAsync(request.Id);
            if (!isDeleted)
            {
                throw new InvalidOperationException($"Failed to delete chronic disease with Id {request.Id}.");
            }
            return isDeleted;
        }
    }
}