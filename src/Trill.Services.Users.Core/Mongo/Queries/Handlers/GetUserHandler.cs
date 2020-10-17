using System;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using Trill.Services.Users.Core.DTO;
using Trill.Services.Users.Core.Mongo.Documents;
using Trill.Services.Users.Core.Queries;

namespace Trill.Services.Users.Core.Mongo.Queries.Handlers
{
    public class GetUserHandler : IQueryHandler<GetUser, UserDetailsDto>
    {
        private readonly IMongoRepository<UserDocument, Guid> _userRepository;

        public GetUserHandler(IMongoRepository<UserDocument, Guid> userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<UserDetailsDto> HandleAsync(GetUser query)
        {
            var user = await _userRepository.GetAsync(query.UserId);
            
            return user is null
                ? null
                : new UserDetailsDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Role = user.Role,
                    CreatedAt = user.CreatedAt,
                    Locked = user.Locked,
                    Permissions = user.Permissions,
                    Funds = user.Funds
                };
        }
    }
}