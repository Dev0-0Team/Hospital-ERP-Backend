namespace Hospital_ERP_Backend.Domain.Entities;

public partial class RoomType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}
