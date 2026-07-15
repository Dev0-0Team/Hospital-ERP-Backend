using MediatR;

namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.DeleteRadiologyImage
{
    public record DeleteRadiologyImageRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}