namespace Hospital_ERP_Backend.Domain.Entities;

public partial class RadiologyReport : BaseEntity
{
    public int RadiologyOrderId { get; set; }

    public string Report { get; set; } = null!;

    public RadiologyOrder RadiologyOrder { get; set; } = null!;
}
