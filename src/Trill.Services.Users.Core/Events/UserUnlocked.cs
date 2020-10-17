using System;
using Convey.CQRS.Events;

namespace Trill.Services.Users.Core.Events
{
    public class UserUnlocked : IEvent
    {
        public Guid UserId { get; }

        public UserUnlocked(Guid userId)
        {
            UserId = userId;
        }
    }
}