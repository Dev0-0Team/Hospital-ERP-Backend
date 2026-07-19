
using Hospital_ERP_Backend.Domain.Entities;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Commands.CreateAllergy
{
    public record CreateAllergyResponse 
    {
        public int Id { get; set; }

        public string AllergyName { get; set; } = null!;

        public string Severity { get; set; } = null!;

        

    }
}
