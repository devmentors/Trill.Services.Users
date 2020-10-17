using System;

namespace Trill.Services.Users.Core.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Locked { get; set; }
        public bool IsFollowing { get; set; }
    }
}