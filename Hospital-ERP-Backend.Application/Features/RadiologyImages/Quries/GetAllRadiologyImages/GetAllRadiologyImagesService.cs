using FluentValidation;
using Hospital_ERP_Backend.Domain.Entities;
using Hospital_ERP_Backend.Domain.Interfaces.Base;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetAllRadiologyImages
{
    public class GetAllRadiologyImagesService
        : IRequestHandler<GetAllRadiologyImagesRequest,
            IEnumerable<GetAllRadiologyImagesResponse>>
    {
        private readonly IBaseQueryRepository<RadiologyImage> _repository;

        private readonly IValidator<GetAllRadiologyImagesRequest> _validator;

        public GetAllRadiologyImagesService(
            IBaseQueryRepository<RadiologyImage> repository,
            IValidator<GetAllRadiologyImagesRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetAllRadiologyImagesResponse>> Handle(
            GetAllRadiologyImagesRequest request,
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

            var images =
                await _repository.GetAllAsync(request.Page);

            if (images == null || !images.Any())
            {
                throw new KeyNotFoundException(
                    $"No Radiology Images found on page {request.Page}");
            }

            return images.Select(x => new GetAllRadiologyImagesResponse
            {
                Id = x.Id,
                RadiologyOrderId = x.RadiologyOrderId,
                ImageUrl = x.ImageUrl
            });
        }
    }
}