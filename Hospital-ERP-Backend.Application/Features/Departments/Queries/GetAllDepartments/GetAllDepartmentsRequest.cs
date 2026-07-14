using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Departments.Queries.GetAllDepartments
{
    public record GetAllDepartmentsRequest : IRequest<IEnumerable<GetAllDepartmentsResponse>>
    {
        public int Page { get; set; }
    }
}
