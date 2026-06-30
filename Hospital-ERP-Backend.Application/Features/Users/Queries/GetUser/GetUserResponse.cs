

namespace Hospital_ERP_Backend.Application.Features.Users.Queries.GetUser
{
    public class GetUserResponse
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string Email { get; set; } = null!;

        public string Status { get; set; } = null!;
    }
}
