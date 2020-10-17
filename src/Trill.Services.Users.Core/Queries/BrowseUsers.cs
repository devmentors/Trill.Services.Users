using System;
using Convey.CQRS.Queries;
using Trill.Services.Users.Core.DTO;

namespace Trill.Services.Users.Core.Queries
{
    public class BrowseUsers : PagedQueryBase, IQuery<PagedDto<UserDto>>
    {
        public Guid? UserId { get; set; }
    }
}