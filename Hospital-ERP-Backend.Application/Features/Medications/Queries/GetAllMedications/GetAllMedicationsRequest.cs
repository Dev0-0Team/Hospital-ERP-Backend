using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Medications.Queries.GetAllMedications
{
    public class GetAllMedicationsRequest : IRequest<List<GetAllMedicationsResponse>>
    {
        public int Page { get; set; }
    }
}