using Hospital_ERP_Backend.Domain.Entities;
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergys.Queries.GetAllAllergy
{
    public record GetAllAllergyRequest : IRequest<IEnumerable<GetAllAllergyResponse>>
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string AllergyName { get; set; } = null!;

        public string Severity { get; set; } = null!;



    }
}
