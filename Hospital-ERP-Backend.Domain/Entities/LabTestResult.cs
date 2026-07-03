

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class LabTestResult : BaseEntity
{
    public int LabOrderId { get; set; }

    public int LabTestId { get; set; }

    public string Result { get; set; } = null!;

    public LabOrder LabOrder { get; set; } = null!; 

    public LabTest LabTest { get; set; } = null!;
}
