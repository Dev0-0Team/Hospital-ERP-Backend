namespace Hospital_ERP_Backend.Domain.Entities;

public partial class RadiologyReport
{
    public int Id { get; set; }

    public int RadiologyOrderId { get; set; }

    public string Report { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public RadiologyOrder RadiologyOrder { get; set; } = null!;
}
