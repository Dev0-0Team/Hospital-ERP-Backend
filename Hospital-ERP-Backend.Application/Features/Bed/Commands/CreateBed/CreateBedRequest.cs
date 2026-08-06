using Hospital_ERP_Backend.Domain.Enums;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Beds.Commands.CreateBed
{
    public record CreateBedRequest : IRequest<CreateBedResponse>
    {
        public int RoomId { get; set; }
        public string BedNumber { get; set; } = null!;
        public BedStatus Status { get; set; } 
    }
}