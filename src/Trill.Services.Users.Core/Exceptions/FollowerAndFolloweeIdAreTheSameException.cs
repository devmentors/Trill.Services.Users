using System;

namespace Trill.Services.Users.Core.Exceptions
{
    public class FollowerAndFolloweeIdAreTheSameException : AppException
    {
        public Guid UserId { get; }

        public FollowerAndFolloweeIdAreTheSameException(Guid userId)
            : base($"Follower and followee are the same user with ID: '{userId}'.")
        {
            UserId = userId;
        }
    }
}