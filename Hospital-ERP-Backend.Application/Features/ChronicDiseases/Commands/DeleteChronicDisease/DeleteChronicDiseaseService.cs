using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.DeleteChronicDisease
{
    public class DeleteChronicDiseaseService
        : IRequestHandler<DeleteChronicDiseaseRequest, bool>
    {
        private readonly IBaseCommandRepository<ChronicDisease> _repository;
        private readonly IBaseQueryRepository<ChronicDisease> _queryRepository;
        private readonly IValidator<DeleteChronicDiseaseRequest> _validator;

        public DeleteChronicDiseaseService(
            IBaseCommandRepository<ChronicDisease> repository,
            IBaseQueryRepository<ChronicDisease> queryRepository,
            IValidator<DeleteChronicDiseaseRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(
            DeleteChronicDiseaseRequest request,
            CancellationToken cancellationToken)
        {
            return await DeleteChronicDiseaseAsync(request);
        }

        private async Task<bool> DeleteChronicDiseaseAsync(
            DeleteChronicDiseaseRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            ChronicDisease? disease =
                await _queryRepository.GetAsync(request.Id);

            if (disease == null)
            {
                throw new KeyNotFoundException(
                    $"Chronic Disease with Id {request.Id} not found.");
            }

            return await _repository.DeleteAsync(request.Id);
        }
    }
}