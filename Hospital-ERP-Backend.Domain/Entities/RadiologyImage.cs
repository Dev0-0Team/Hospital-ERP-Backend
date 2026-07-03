namespace Hospital_ERP_Backend.Domain.Entities;

public partial class RadiologyImage : BaseEntity
{
    public int RadiologyOrderId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public RadiologyOrder RadiologyOrder { get; set; } = null!;
}
