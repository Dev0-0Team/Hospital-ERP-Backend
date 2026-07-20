using MediatR;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.UpdateChronicDisease
{
    public record UpdateChronicDiseaseRequest() : IRequest<UpdateChronicDiseaseResponse>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string DiseaseName { get; set; } = null!;
    }
}
