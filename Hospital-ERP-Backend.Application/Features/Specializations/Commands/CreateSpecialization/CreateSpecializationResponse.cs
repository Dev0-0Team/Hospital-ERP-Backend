

namespace Hospital_ERP_Backend.Application.Features.Specializations.Commands.CreateSpecialization
{
    public record CreateSpecializationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
