using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Trill.Services.Users.Core.Domain.Repositories;
using Trill.Services.Users.Core.Events;
using Trill.Services.Users.Core.Exceptions;
using Trill.Services.Users.Core.Services;

namespace Trill.Services.Users.Core.Commands.Handlers
{
    internal sealed class LockUserHandler : ICommandHandler<LockUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageBroker _messageBroker;

        public LockUserHandler(IUserRepository userRepository, IMessageBroker messageBroker)
        {
            _userRepository = userRepository;
            _messageBroker = messageBroker;
        }
        
        public async Task HandleAsync(LockUser command)
        {
            var user = await _userRepository.GetAsync(command.UserId);
            if (user is null)
            {
                throw new UserNotFoundException(command.UserId);
            }

            if (user.Lock())
            {
                await _userRepository.UpdateAsync(user);
                await _messageBroker.PublishAsync(new UserLocked(user.Id));
            }
        }
    }
}