using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.DeleteNurse
{
    public record DeleteNurseRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
