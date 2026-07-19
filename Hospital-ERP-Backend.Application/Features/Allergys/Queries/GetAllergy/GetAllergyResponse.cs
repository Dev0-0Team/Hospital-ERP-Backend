
using Hospital_ERP_Backend.Domain.Entities;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Queries.GetAllergy
{
    public record GetAllergyResponse
    {
        public int PatientId { get; set; }
        public int ID { get; set; }
        public string AllergyName { get; set; } = null!;

        public string Severity { get; set; } = null!;



    }
}
