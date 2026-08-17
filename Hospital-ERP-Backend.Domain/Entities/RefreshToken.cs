using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_ERP_Backend.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public int UserId { get; set; }

        public string TokenHash { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }

        public DateTime? RevokedAt { get; set; }

        public User User { get; set; } = null!;
    }
}