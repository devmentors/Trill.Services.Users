using System;
using Convey.CQRS.Events;

namespace Trill.Services.Users.Core.Events
{
    public class UserLocked : IEvent
    {
        public Guid UserId { get; }

        public UserLocked(Guid userId)
        {
            UserId = userId;
        }
    }
}