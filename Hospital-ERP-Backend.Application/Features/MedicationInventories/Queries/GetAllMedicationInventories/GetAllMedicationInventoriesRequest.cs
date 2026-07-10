using MediatR;

namespace Hospital_ERP_Backend.Application.Features.MedicationInventories.Queries.GetAllMedicationInventories
{
    public record GetAllMedicationInventoriesRequest : IRequest<IEnumerable<GetAllMedicationInventoriesResponse>>
    {
        public int Page { get; set; }
    }
}