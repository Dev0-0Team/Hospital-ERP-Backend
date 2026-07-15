namespace Hospital_ERP_Backend.Application.Features.RadiologyImages.Queries.GetAllRadiologyImages
{
    public record GetAllRadiologyImagesResponse
    {
        public int Id { get; set; }

        public int RadiologyOrderId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}