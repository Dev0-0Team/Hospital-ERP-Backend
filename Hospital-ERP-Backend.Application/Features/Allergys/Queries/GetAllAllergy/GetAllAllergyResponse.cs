
using Hospital_ERP_Backend.Domain.Entities;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Queries.GetAllAllergy
{
    public record GetAllAllergyResponse
    {
        public int PatientId { get; set; }

        public string AllergyName { get; set; } = null!;

        public string Severity { get; set; } = null!;



    }
}
