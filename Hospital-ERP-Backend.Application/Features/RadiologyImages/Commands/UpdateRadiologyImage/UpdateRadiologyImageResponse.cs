namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.UpdateRadiologyImage
{
    public record UpdateRadiologyImageResponse
    {
        public int Id { get; set; }

        public int RadiologyOrderId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}