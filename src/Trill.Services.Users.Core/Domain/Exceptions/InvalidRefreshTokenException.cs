namespace Trill.Services.Users.Core.Domain.Exceptions
{
    public class InvalidRefreshTokenException : DomainException
    {
        public InvalidRefreshTokenException() : base("Invalid refresh token.")
        {
        }
    }
}