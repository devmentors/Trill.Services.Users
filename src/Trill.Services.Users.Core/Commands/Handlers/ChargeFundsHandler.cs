using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Trill.Services.Users.Core.Domain.Repositories;
using Trill.Services.Users.Core.Exceptions;

namespace Trill.Services.Users.Core.Commands.Handlers
{
    internal sealed class ChargeFundsHandler : ICommandHandler<ChargeFunds>
    {
        private readonly IUserRepository _userRepository;

        public ChargeFundsHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task HandleAsync(ChargeFunds command)
        {
            var user = await _userRepository.GetAsync(command.UserId);
            if (user is null)
            {
                throw new UserNotFoundException(command.UserId);
            }

            user.ChargeFunds(command.Amount);
            await _userRepository.UpdateAsync(user);
        }
    }
}