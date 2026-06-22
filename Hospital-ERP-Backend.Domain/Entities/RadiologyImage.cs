namespace Hospital_ERP_Backend.Domain.Entities;

public partial class RadiologyImage
{
    public int Id { get; set; }

    public int RadiologyOrderId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public RadiologyOrder RadiologyOrder { get; set; } = null!;
}
