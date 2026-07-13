namespace Hospital_ERP_Backend.Application.Features.Beds.Queries.GetAllBeds
{
    public record GetAllBedsResponse
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string BedNumber { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}