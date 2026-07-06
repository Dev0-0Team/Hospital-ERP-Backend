using Hospital_ERP_Backend.Application.Features.Medications.Queries.GetAllMedications;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Medications.Queries.GetMedicationById
{
    public class GetMedicationRequest : IRequest<GetMedicationResponse>
    {
        public int Id { get; set; }
    }
}
