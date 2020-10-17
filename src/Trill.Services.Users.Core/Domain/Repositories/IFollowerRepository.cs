using System.Threading.Tasks;
using Trill.Services.Users.Core.Domain.Entities;

namespace Trill.Services.Users.Core.Domain.Repositories
{
    public interface IFollowerRepository
    {
        Task<Follower> GetAsync(AggregateId followerId, AggregateId followeeId);
        Task AddAsync(Follower follower);
        Task DeleteAsync(AggregateId id);
    }
}