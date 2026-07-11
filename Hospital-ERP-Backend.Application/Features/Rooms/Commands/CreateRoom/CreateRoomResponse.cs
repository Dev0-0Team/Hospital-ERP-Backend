namespace Hospital_ERP_Backend.Application.Features.Rooms.Commands.CreateRoom
{
    public record CreateRoomResponse
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}