namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetRadiologyImage
{
    public record GetRadiologyImageResponse
    {
        public int Id { get; set; }

        public int RadiologyOrderId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}