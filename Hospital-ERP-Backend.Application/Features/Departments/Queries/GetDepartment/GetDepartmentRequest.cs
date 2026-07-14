
using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Departments.Queries.GetDepartment
{
    public record GetDepartmentRequest : IRequest<GetDepartmentResponse>
    {
        public int Id { get; set; }
    }
}
