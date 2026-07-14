using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Beds.Commands.DeleteBed
{
    public record DeleteBedRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}