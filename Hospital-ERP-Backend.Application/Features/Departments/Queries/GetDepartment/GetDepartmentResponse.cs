

namespace Hospital_ERP_Backend.Application.Features.Departments.Queries.GetDepartment
{
    public record GetDepartmentResponse 
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
