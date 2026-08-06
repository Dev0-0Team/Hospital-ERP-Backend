using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetRadiologyImage
{
    internal class GetRadiologyImageService
        : IRequestHandler<GetRadiologyImageRequest,
            GetRadiologyImageResponse>
    {
        private readonly IBaseQueryRepository<RadiologyImage> _repository;

        private readonly IValidator<GetRadiologyImageRequest> _validator;

        public GetRadiologyImageService(
            IBaseQueryRepository<RadiologyImage> repository,
            IValidator<GetRadiologyImageRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<GetRadiologyImageResponse> Handle(
            GetRadiologyImageRequest request,
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

            var image =
                await _repository.GetAsync(request.Id);

            if (image == null)
            {
                throw new KeyNotFoundException(
                    $"Radiology Image with Id {request.Id} not found.");
            }

            return new GetRadiologyImageResponse
            {
                Id = image.Id,
                RadiologyOrderId = image.RadiologyOrderId,
                ImageUrl = image.ImageUrl
            };
        }
    }
}