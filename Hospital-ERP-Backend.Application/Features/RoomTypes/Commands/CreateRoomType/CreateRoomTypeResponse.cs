namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.CreateRoomType
{
    public record CreateRoomTypeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}