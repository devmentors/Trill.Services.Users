using System;
using Convey.CQRS.Commands;

namespace Trill.Services.Users.Core.Commands
{
    public class AddFunds : ICommand
    {
        public Guid UserId { get; }
        public decimal Amount { get; }

        public AddFunds(Guid userId, decimal amount)
        {
            UserId = userId;
            Amount = amount;
        }
    }
}