using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Allergies.Commands.DeleteAllergy
{
    public record DeleteAllergyRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}