using System;
using Convey.MessageBrokers.RabbitMQ;
using Trill.Services.Users.Core.Domain.Exceptions;
using Trill.Services.Users.Core.Events;

namespace Trill.Services.Users.Core.Exceptions
{
    internal sealed class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(Exception exception, object message)
            => exception switch
            {
                DomainException ex => new UserActionRejected(ex.Message, ex.GetExceptionCode()),
                _ => new UserActionRejected("There was an error", "user_error")
            };
    }
}

