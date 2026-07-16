using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.CreateNurse
{
    public record CreateNurseRequest : IRequest<CreateNurseResponse>
    {
        public int PersonId {  get; set; }
        public int DepartmentId { get; set; }
    }
}
