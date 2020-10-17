using System.Threading.Tasks;
using Trill.Services.Users.Core.Domain.Entities;

namespace Trill.Services.Users.Core.Domain.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken refreshToken);
        Task UpdateAsync(RefreshToken refreshToken);
    }
}