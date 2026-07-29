

using MediatR;

namespace Hospital_ERP_Backend.Application.Features.AdministrativeStaffs.Queries.GetAllAdministrativeStaffs
{
    public record GetAllAdministrativeStaffsRequest : IRequest<IEnumerable<GetAllAdministrativeStaffsResponse>>
    {
        public int Page {get; set;}
    }
}