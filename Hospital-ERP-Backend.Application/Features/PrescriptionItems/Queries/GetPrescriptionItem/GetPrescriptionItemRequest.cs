using MediatR;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Queries.GetPrescriptionItem
{
    public record GetPrescriptionItemRequest : IRequest<GetPrescriptionItemResponse>
    {
        public int Id { get; set; }
    }
}