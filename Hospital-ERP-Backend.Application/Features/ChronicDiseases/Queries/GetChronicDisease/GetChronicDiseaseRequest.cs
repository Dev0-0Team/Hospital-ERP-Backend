using MediatR;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Queries.GetChronicDisease
{
    public record GetChronicDiseaseRequest : IRequest<GetChronicDiseaseResponse>
    {
        public int Id { get; set; }

    }
}
