using MediatR;


namespace Hospital_ERP_Backend.Application.Features.Specializations.Command.DeleteSpecialization
{
    public record DeleteSpecializationRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
