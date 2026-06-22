
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Notification
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Body { get; set; } = null!;

    public bool? IsRead { get; set; }

    public DateTime? CreatedAt { get; set; }

    public User User { get; set; } = null!;
}
