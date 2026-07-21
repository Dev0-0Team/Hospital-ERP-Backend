using MediatR;

namespace Hospital_ERP_Backend.Application.Features.ChronicDiseases.Queries.GetAllChronicDiseases
{
    public record GetAllChronicDiseasesRequest : IRequest<IEnumerable<GetAllChronicDiseasesResponse>>
    {
        public int Page { get; set; }

    }
}
