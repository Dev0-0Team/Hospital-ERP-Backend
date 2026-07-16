using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Specializations.Commands.DeleteSpecialization
{
    public record DeleteSpecializationRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
