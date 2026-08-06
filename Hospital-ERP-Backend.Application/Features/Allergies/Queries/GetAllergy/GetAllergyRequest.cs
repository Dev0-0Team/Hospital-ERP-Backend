using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Queries.GetAllergy
{
    public record GetAllergyRequest : IRequest<GetAllergyResponse>
    {
        public int Id { get; set; }
    }
}