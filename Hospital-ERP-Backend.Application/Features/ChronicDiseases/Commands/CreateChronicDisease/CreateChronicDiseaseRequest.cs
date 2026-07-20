using MediatR;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Commands.CreateChronicDisease
{
    public class CreateChronicDiseaseRequest : IRequest<CreateChronicDiseaseResponse>
    {
        public int PatientId { get; set; }

        public string DiseaseName { get; set; } = null!;
    }
}
