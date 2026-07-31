using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.UpdateRadiologyImage
{
    internal class UpdateRadiologyImageService
    : IRequestHandler<UpdateRadiologyImageRequest, UpdateRadiologyImageResponse>
    {
        private readonly IBaseCommandRepository<RadiologyImage> _repository;

        private readonly IBaseQueryRepository<RadiologyImage> _queryRepository;

        private readonly IValidator<UpdateRadiologyImageRequest> _validator;

        public UpdateRadiologyImageService(
            IBaseCommandRepository<RadiologyImage> repository,
            IBaseQueryRepository<RadiologyImage> queryRepository,
            IValidator<UpdateRadiologyImageRequest> validator)
        {
            _repository = repository;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<UpdateRadiologyImageResponse> Handle(
            UpdateRadiologyImageRequest request,
            CancellationToken cancellationToken)
        {
            return await UpdateRadiologyImageAsync(request);
        }

        private async Task<UpdateRadiologyImageResponse> UpdateRadiologyImageAsync(
            UpdateRadiologyImageRequest request)
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

            image.RadiologyOrderId = request.RadiologyOrderId;
            image.ImageUrl = request.ImageUrl;
            image.UpdatedAt = DateTime.UtcNow;

            RadiologyImage? result =
                await _repository.UpdateAsync(image);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to update Radiology Image.");
            }

            return new UpdateRadiologyImageResponse
            {
                Id = result.Id,
                RadiologyOrderId = result.RadiologyOrderId,
                ImageUrl = result.ImageUrl
            };
        }
    }

}
