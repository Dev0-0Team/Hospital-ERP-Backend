

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class LabTestResult
{
    public int Id { get; set; }

    public int LabOrderId { get; set; }

    public int LabTestId { get; set; }

    public string Result { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public LabOrder LabOrder { get; set; } = null!; 
    public LabTest LabTest { get; set; } = null!;
}
