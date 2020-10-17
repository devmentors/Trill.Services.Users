using System;
using Convey.CQRS.Queries;
using Trill.Services.Users.Core.DTO;

namespace Trill.Services.Users.Core.Queries
{
    public class GetUser : IQuery<UserDetailsDto>
    {
        public Guid UserId { get; set; }
    }
}