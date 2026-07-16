
namespace Hospital_ERP_Backend.Application.Features.Specializations.Commands.UpdateSpecialization
{
    public record UpdateSpecializationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
