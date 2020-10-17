using System;
using Convey.CQRS.Commands;

namespace Trill.Services.Users.Core.Commands
{
    public class UseRefreshToken : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string RefreshToken { get; }

        public UseRefreshToken(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}