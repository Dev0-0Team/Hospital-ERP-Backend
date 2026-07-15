using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.CreateRadiologyImage
{
    public record CreateRadiologyImageRequest
        : IRequest<CreateRadiologyImageResponse>
    {
        public int RadiologyOrderId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}