

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class LabTest : BaseEntity
{
    public string Name { get; set; } = null!;

    public string NormalRange { get; set; } = null!;

    public ICollection<LabTestResult> LabTestResults { get; set; } = new List<LabTestResult>();
}
