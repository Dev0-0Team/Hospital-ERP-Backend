

namespace Hospital_ERP_Backend.Application.Features.Nurses.Commands.UpdateNurse
{
    public record UpdateNurseResponse
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int DepartmentId { get; set; }
    }
}
