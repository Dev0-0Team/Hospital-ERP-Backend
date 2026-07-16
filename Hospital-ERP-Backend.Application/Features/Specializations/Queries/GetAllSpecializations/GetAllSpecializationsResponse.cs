

namespace Hospital_ERP_Backend.Application.Features.Specializations.Queries.GetAllSpecializations
{
    public record GetAllSpecializationsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
