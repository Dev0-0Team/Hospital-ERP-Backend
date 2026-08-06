using Hospital_ERP_Backend.Domain.Enums;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Commands.UpdateAllergy
{
    public record UpdateAllergyRequest : IRequest<UpdateAllergyResponse>
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string AllergyName { get; set; } = null!;

        public AllergySeverity Severity { get; set; }
    }
}