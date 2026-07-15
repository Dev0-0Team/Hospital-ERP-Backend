namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Commands.CreateRadiologyImage
{
    public record CreateRadiologyImageResponse
    {
        public int Id { get; set; }

        public int RadiologyOrderId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}