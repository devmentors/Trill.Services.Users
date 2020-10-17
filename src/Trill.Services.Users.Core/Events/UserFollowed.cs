using System;
using Convey.CQRS.Events;

namespace Trill.Services.Users.Core.Events
{
    public class UserFollowed : IEvent
    {
        public Guid FollowerId { get; }
        public Guid FolloweeId { get; }

        public UserFollowed(Guid followerId, Guid followeeId)
        {
            FollowerId = followerId;
            FolloweeId = followeeId;
        }
    }
}