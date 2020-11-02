using System.Collections.Generic;

namespace Trill.Services.Users.Core.DTO
{
    public class UserDetailsDto : UserDto
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public IEnumerable<string> Permissions { get; set; }
        public decimal Funds { get; set; }
    }
}