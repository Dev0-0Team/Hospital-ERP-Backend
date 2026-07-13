namespace Hospital_ERP_Backend.Application.Features.Beds.Commands.UpdateBed
{
    public record UpdateBedResponse
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string BedNumber { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}