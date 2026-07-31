using Hospital_ERP_Backend.Domain.Enums;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Beds.Commands.UpdateBed
{
    public record UpdateBedRequest : IRequest<UpdateBedResponse>
    {
        public int Id { get; init; }
        public int RoomId { get; init; }
        public string BedNumber { get; init; } = null!;
        public BedStatus Status { get; init; }
    }
}