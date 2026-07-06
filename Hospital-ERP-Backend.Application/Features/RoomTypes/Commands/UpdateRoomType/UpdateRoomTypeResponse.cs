namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.UpdateRoomType
{
    public record UpdateRoomTypeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}