namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Room : BaseEntity
{
    public int DepartmentId { get; set; }

    public int RoomTypeId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string Status { get; set; } = null!;

    public ICollection<Bed> Beds { get; set; } = new List<Bed>();

    public Department Department { get; set; } = null!;

    public RoomType RoomType { get; set; } = null!;
}
