namespace Hospital_ERP_Backend.Application.Features.RoomTypes.Queries.GetAllRoomTypes
{
    public record GetAllRoomTypesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}