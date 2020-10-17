using System.Threading.Tasks;
using Convey.CQRS.Events;

namespace Trill.Services.Users.Core.Services
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IEvent[] events);
    }
}