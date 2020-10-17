using System;
using System.Collections.Generic;
using Convey.CQRS.Commands;

namespace Trill.Services.Users.Core.Commands
{
    public class CreateUser : ICommand
    {
        public Guid UserId { get; }
        public string Email { get; }
        public string Name { get; }
        public string Password { get; }
        public string Role { get; }
        public IEnumerable<string> Permissions { get; }

        public CreateUser(Guid userId, string email, string name, string password, string role,
            IEnumerable<string> permissions)
        {
            UserId = userId == Guid.Empty ? Guid.NewGuid() : userId;
            Email = email;
            Name = name;
            Password = password;
            Role = role;
            Permissions = permissions;
        }
    }
}