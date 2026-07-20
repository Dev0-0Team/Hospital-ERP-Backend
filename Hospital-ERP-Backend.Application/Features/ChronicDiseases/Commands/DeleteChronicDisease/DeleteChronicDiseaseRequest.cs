using MediatR;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.DeleteChronicDisease
{
    public record DeleteChronicDiseaseRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}