namespace Hospital_ERP_Backend.Application.Features.Rooms.Queries.GetRoom
{
    public record GetRoomResponse
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}