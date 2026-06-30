

namespace Hospital_ERP_Backend.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserRequest
    {
        public int PersonId { get; set; }

        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public string Status { get; set; } = null!;
    }
}
