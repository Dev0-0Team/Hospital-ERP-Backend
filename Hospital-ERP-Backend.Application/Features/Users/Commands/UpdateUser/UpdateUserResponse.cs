
namespace Hospital_ERP_Backend.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserResponse
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Email { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
