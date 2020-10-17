using System;
using Trill.Services.Users.Core.DTO;

namespace Trill.Services.Users.Core.Services
{
    public interface ITokenStorage
    {
        void Set(Guid commandId, AuthDto token);
        AuthDto Get(Guid commandId);
    }
}