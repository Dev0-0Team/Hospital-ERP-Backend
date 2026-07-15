using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetRadiologyImage
{
    public record GetRadiologyImageRequest
        : IRequest<GetRadiologyImageResponse>
    {
        public int Id { get; set; }
    }
}