using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.DeleteRadiologyImage
{
    public class DeleteRadiologyImageService
    : IRequestHandler<DeleteRadiologyImageRequest, bool>
    {
        private readonly IBaseCommandRepository<RadiologyImage> _repository;

        private readonly IBaseQueryRepository<RadiologyImage> _queryRepository;

        private readonly IValidator<DeleteRadiologyImageRequest> _validator;

        public DeleteRadiologyImageService(
            IBaseCommandRepository<RadiologyImage> repository,
            IBaseQueryRepository<RadiologyImage> queryRepository,
            IValidator<DeleteRadiologyImageRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(
            DeleteRadiologyImageRequest request,
            CancellationToken cancellationToken)
        {
            return await DeleteRadiologyImageAsync(request);
        }

        private async Task<bool> DeleteRadiologyImageAsync(
            DeleteRadiologyImageRequest request)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            RadiologyImage? image =
                await _queryRepository.GetAsync(request.Id);

            if (image == null)
            {
                throw new KeyNotFoundException(
                    $"Radiology Image with Id {request.Id} not found.");
            }

            bool isDeleted =
                await _repository.DeleteAsync(image.Id);

            if (!isDeleted)
            {
                throw new InvalidOperationException(
                    $"Failed to delete Radiology Image with Id {request.Id}.");
            }

            return isDeleted;
        }
    }

}
