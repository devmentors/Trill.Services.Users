using System;

namespace Trill.Services.Users.Core.Domain.Exceptions
{
    public class InsufficientFundsException : DomainException
    {
        public Guid UserId { get; }

        public InsufficientFundsException(Guid userId) : base($"User with ID: '{userId}' has insufficient funds.")
        {
            UserId = userId;
        }
    }
}