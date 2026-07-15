using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetAllRadiologyImages
{
    public record GetAllRadiologyImagesRequest
        : IRequest<IEnumerable<GetAllRadiologyImagesResponse>>
    {
        public int Page { get; set; }
    }
}