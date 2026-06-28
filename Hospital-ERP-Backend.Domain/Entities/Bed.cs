
namespace Hospital_ERP_Backend.Domain.Entities;

public partial class Bed
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public string BedNumber { get; set; } = null!;

    public string Status { get; set; } = null!;

    public Room Room { get; set; } = null!;

    public ICollection<RoomAssignment> RoomAssignments { get; set; } = new List<RoomAssignment>();
}
