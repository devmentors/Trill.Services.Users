using System;

namespace Trill.Services.Users.Core.Domain.Entities
{
    public class Follower : AggregateRoot
    {
        public AggregateId FollowerId { get; }
        public AggregateId FolloweeId { get; }
        public DateTime CreatedAt { get; }

        public Follower(AggregateId id, AggregateId followerId, AggregateId followeeId, DateTime createdAt) : base(id)
        {
            FollowerId = followerId;
            FolloweeId = followeeId;
            CreatedAt = createdAt;
        }
    }
}