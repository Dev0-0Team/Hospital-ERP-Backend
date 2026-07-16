

namespace Hospital_ERP_Backend.Application.Features.Specializations.Queries.GetSpecialization
{
    public record GetSpecializationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
