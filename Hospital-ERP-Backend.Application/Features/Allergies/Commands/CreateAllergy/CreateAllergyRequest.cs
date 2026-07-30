using Hospital_ERP_Backend.Domain.Enums;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Commands.CreateAllergy
{
    public record CreateAllergyRequest : IRequest<CreateAllergyResponse>
    {
        public int PatientId { get; set; }

        public string AllergyName { get; set; } = null!;

        public AllergySeverity Severity { get; set; }
    }
}