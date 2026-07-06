

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class PaymentMethod : BaseEntity
{
    public string Name { get; set; } = null!;

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
