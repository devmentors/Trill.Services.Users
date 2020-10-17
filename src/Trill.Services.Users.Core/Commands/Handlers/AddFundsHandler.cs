using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Trill.Services.Users.Core.Domain.Repositories;
using Trill.Services.Users.Core.Exceptions;

namespace Trill.Services.Users.Core.Commands.Handlers
{
    internal sealed class AddFundsHandler : ICommandHandler<AddFunds>
    {
        private readonly IUserRepository _userRepository;

        public AddFundsHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task HandleAsync(AddFunds command)
        {
            var user = await _userRepository.GetAsync(command.UserId);
            if (user is null)
            {
                throw new UserNotFoundException(command.UserId);
            }

            user.AddFunds(command.Amount);
            await _userRepository.UpdateAsync(user);
        }
    }
}