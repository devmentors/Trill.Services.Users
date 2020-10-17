using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Trill.Services.Users.Core.Domain.Repositories;
using Trill.Services.Users.Core.Events;
using Trill.Services.Users.Core.Exceptions;
using Trill.Services.Users.Core.Services;

namespace Trill.Services.Users.Core.Commands.Handlers
{
    internal sealed class UnfollowUserHandler : ICommandHandler<UnfollowUser>
    {
        private readonly IFollowerRepository _followerRepository;
        private readonly IMessageBroker _messageBroker;

        public UnfollowUserHandler(IFollowerRepository  followerRepository, IMessageBroker messageBroker)
        {
            _followerRepository = followerRepository;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(UnfollowUser command)
        {
            if (command.UserId == command.FolloweeId)
            {
                throw new FollowerAndFolloweeIdAreTheSameException(command.UserId);
            }
            
            var follower = await _followerRepository.GetAsync(command.UserId, command.FolloweeId);
            if (follower is null)
            {
                return;
            }

            await _followerRepository.DeleteAsync(follower.Id);
            await _messageBroker.PublishAsync(new UserUnfollowed(command.UserId, command.FolloweeId));
        }
    }
}