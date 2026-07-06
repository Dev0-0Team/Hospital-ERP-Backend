namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetRoomType
{
    public record GetRoomTypeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}