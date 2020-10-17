using System;
using Convey.CQRS.Commands;

namespace Trill.Services.Users.Core.Commands
{
    public class UnfollowUser : ICommand
    {
        public Guid UserId { get; }
        public Guid FolloweeId { get; }

        public UnfollowUser(Guid userId, Guid followeeId)
        {
            UserId = userId;
            FolloweeId = followeeId;
        }
    }
}