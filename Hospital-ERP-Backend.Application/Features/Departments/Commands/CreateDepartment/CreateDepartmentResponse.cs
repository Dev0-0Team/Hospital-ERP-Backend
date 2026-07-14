

using Microsoft.Identity.Client;

namespace Hospital_ERP_Backend.Application.Features.Departments.Commands.CreateDepartment
{
    public record CreateDepartmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
