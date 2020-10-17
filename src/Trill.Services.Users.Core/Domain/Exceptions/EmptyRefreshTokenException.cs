namespace Trill.Services.Users.Core.Domain.Exceptions
{
    public class EmptyRefreshTokenException : DomainException
    {
        public EmptyRefreshTokenException() : base("Empty refresh token.")
        {
        }
    }
}