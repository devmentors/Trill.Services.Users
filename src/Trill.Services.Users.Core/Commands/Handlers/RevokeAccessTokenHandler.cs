using System.Threading.Tasks;
using Convey.Auth;
using Convey.CQRS.Commands;

namespace Trill.Services.Users.Core.Commands.Handlers
{
    internal sealed class RevokeAccessTokenHandler : ICommandHandler<RevokeAccessToken>
    {
        private readonly IAccessTokenService _accessTokenService;

        public RevokeAccessTokenHandler(IAccessTokenService accessTokenService)
        {
            _accessTokenService = accessTokenService;
        }
        
        public async Task HandleAsync(RevokeAccessToken command)
        {
            await _accessTokenService.DeactivateAsync(command.AccessToken);
        }
    }
}