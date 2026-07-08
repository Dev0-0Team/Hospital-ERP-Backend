using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Medications.Queries.GetAllMedications
{
    public record GetAllMedicationsRequest : IRequest<IEnumerable<GetAllMedicationsResponse>>
    {
        public int Page { get; set; }
    }
}