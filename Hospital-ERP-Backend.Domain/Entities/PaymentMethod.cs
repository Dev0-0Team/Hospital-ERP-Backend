

namespace Hospital_ERP_Backend.Domain.Entities;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
