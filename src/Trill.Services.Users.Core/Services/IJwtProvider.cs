using System;
using System.Collections.Generic;
using Trill.Services.Users.Core.DTO;

namespace Trill.Services.Users.Core.Services
{
    public interface IJwtProvider
    {
        AuthDto Create(Guid userId, string username, string role, string audience = null,
            IDictionary<string, IEnumerable<string>> claims = null);
    }
}