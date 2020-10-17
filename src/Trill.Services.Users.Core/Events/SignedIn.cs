using System;
using Convey.CQRS.Events;

namespace Trill.Services.Users.Core.Events
{
    public class SignedIn : IEvent
    {
        public Guid UserId { get; }

        public SignedIn(Guid userId)
        {
            UserId = userId;
        }
    }
}