

namespace Hospital_ERP_Backend.Application.Features.Departments.Commands.UpdateDepartment
{
    public record UpdateDepartmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
