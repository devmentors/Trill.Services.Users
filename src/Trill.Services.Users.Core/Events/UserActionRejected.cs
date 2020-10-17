using Convey.CQRS.Events;

namespace Trill.Services.Users.Core.Events
{
    public class UserActionRejected : IRejectedEvent
    {
        public string Reason { get; }
        public string Code { get; }

        public UserActionRejected(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }
    }
}