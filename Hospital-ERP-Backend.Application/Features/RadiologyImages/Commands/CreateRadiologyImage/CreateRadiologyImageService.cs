using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.CreateRadiologyImage
{
    public class CreateRadiologyImageService
        : IRequestHandler<CreateRadiologyImageRequest,
            CreateRadiologyImageResponse>
    {
        private readonly IBaseCommandRepository<RadiologyImage> _repository;

        private readonly IValidator<CreateRadiologyImageRequest> _validator;

        public CreateRadiologyImageService(
            IBaseCommandRepository<RadiologyImage> repository,
            IValidator<CreateRadiologyImageRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateRadiologyImageResponse> Handle(
            CreateRadiologyImageRequest request,
            CancellationToken cancellationToken)
        {
            var validationResult =
                await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(
                    string.Join(", ",
                    validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            RadiologyImage image = new()
            {
                RadiologyOrderId = request.RadiologyOrderId,
                ImageUrl = request.ImageUrl
            };

            var result =
                await _repository.CreateAsync(image);

            if (result == null)
            {
                throw new InvalidOperationException(
                    "Failed to create Radiology Image.");
            }

            return new CreateRadiologyImageResponse
            {
                Id = result.Id,
                RadiologyOrderId = result.RadiologyOrderId,
                ImageUrl = result.ImageUrl
            };
        }
    }
}