using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Departments.Commands.DeleteDepartment
{
    public record DeleteDepartmentRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
