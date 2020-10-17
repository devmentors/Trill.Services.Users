using System;
using Convey.CQRS.Events;

namespace Trill.Services.Users.Core.Events
{
    public class UserUnfollowed : IEvent
    {
        public Guid FollowerId { get; }
        public Guid FolloweeId { get; }

        public UserUnfollowed(Guid followerId, Guid followeeId)
        {
            FollowerId = followerId;
            FolloweeId = followeeId;
        }
    }
}