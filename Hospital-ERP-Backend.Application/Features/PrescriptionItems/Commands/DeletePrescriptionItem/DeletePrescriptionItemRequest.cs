using MediatR;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Commands.DeletePrescriptionItem
{
    public record DeletePrescriptionItemRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}