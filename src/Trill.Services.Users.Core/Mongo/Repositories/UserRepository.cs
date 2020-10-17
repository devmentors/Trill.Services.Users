using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Trill.Services.Users.Core.Domain.Entities;
using Trill.Services.Users.Core.Domain.Repositories;
using Trill.Services.Users.Core.Mongo.Documents;

namespace Trill.Services.Users.Core.Mongo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoRepository<UserDocument, Guid> _repository;

        public UserRepository(IMongoRepository<UserDocument, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<User> GetAsync(AggregateId id)
        {
            var document = await _repository.GetAsync(id);
            return document?.ToEntity();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return default;
            }
            
            var document = await _repository.GetAsync(x => x.Email == email.ToLowerInvariant());
            return document?.ToEntity();
        }

        public async Task<User> GetByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return default;
            }
            
            var document = await _repository.GetAsync(x => x.Name == name.ToLowerInvariant());
            return document?.ToEntity();
        }

        public Task AddAsync(User user) => _repository.AddAsync(new UserDocument(user));

        public Task UpdateAsync(User user) => _repository.UpdateAsync(new UserDocument(user));
    }
}