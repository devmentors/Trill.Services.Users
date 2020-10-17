using System;
using Convey.Types;
using Trill.Services.Users.Core.Domain.Entities;

namespace Trill.Services.Users.Core.Mongo.Documents
{
    public class FollowerDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid FollowerId { get; set; }
        public Guid FolloweeId { get;  set; }
        public DateTime CreatedAt { get; set; }

        public FollowerDocument()
        {
        }

        public FollowerDocument(Follower follower)
        {
            Id = follower.Id;
            FollowerId = follower.FollowerId;
            FolloweeId = follower.FolloweeId;
            CreatedAt = follower.CreatedAt;
        }

        public Follower ToEntity() => new Follower(Id, FollowerId, FolloweeId, CreatedAt);
    }
}