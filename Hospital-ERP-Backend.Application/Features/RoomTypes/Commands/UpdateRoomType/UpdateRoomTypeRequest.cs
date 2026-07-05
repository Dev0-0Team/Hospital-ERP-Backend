namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.UpdateRoomType
{
    public record UpdateRoomTypeRequest
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
    }
}