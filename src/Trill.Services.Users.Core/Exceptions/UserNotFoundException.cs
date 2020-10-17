using System;

namespace Trill.Services.Users.Core.Exceptions
{
    public class UserNotFoundException : AppException
    {
        public Guid UserId { get; }
        
        public UserNotFoundException(Guid userId) : base($"User with ID: '{userId}' was not found.")
        {
            UserId = userId;
        }
    }
}