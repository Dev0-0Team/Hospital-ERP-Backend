using MediatR;

namespace Hospital_ERP_Backend.Application.Features.Departments.Commands.CreateDepartment
{
    public record CreateDepartmentRequest : IRequest<CreateDepartmentResponse>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
