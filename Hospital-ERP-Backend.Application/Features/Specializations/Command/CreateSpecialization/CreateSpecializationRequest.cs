using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Specializations.Command.CreateSpecialization
{
    public record CreateSpecializationRequest : IRequest<CreateSpecializationResponse>
    {
        public string Name { get; set; } = null!;
    }
}
