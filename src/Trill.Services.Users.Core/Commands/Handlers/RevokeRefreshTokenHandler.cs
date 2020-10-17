using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Trill.Services.Users.Core.Domain.Exceptions;
using Trill.Services.Users.Core.Domain.Repositories;

namespace Trill.Services.Users.Core.Commands.Handlers
{
    internal sealed class RevokeRefreshTokenHandler : ICommandHandler<RevokeRefreshToken>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RevokeRefreshTokenHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }
        
        public async Task HandleAsync(RevokeRefreshToken command)
        {
            var token = await _refreshTokenRepository.GetAsync(command.RefreshToken);
            if (token is null)
            {
                throw new InvalidRefreshTokenException();
            }

            token.Revoke(DateTime.UtcNow);
            await _refreshTokenRepository.UpdateAsync(token);
        }
    }
}