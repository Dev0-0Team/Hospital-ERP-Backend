using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Commands.DeleteAdministrativeStaff
{
    public record DeleteAdministrativeStaffRequest : IRequest<bool>
    {
        public int Id {get; set;}
    }
}