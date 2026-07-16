using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Specializations.Queries.GetSpecialization
{
    public record GetSpecializationRequest : IRequest<GetSpecializationResponse>
    {
        public int Id { get; set; }
    }
}
