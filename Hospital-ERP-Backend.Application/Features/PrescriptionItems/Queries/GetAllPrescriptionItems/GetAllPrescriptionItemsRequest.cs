using MediatR;

namespace Hospital_ERP_Backend.Application.Features.PrescriptionItems.Queries.GetAllPrescriptionItems
{
    public record GetAllPrescriptionItemsRequest : IRequest<IEnumerable<GetAllPrescriptionItemsResponse>>
    {
        public int Page { get; set; }
    }
}