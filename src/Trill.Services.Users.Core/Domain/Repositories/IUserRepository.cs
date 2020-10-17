using System.Threading.Tasks;
using Trill.Services.Users.Core.Domain.Entities;

namespace Trill.Services.Users.Core.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(AggregateId id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByNameAsync(string name);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}