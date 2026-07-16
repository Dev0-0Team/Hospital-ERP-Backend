using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Command.UpdateSpecialization
{
    public record UpdateSpecializationRequest : IRequest<UpdateSpecializationResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
