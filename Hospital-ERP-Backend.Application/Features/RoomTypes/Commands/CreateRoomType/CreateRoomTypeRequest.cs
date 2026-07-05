namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Commands.CreateRoomType
{
    public record CreateRoomTypeRequest 
    {
        public string Name { get; set; } = null!;
    }
}