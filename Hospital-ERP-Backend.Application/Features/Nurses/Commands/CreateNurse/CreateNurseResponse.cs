
namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.CreateNurse
{
    public record CreateNurseResponse
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int DepartmentId { get; set; }
    }
}
