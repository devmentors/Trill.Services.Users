namespace Trill.Services.Users.Core.Domain.Exceptions
{
    public class RevokedRefreshTokenException : DomainException
    {
        public RevokedRefreshTokenException() : base("Revoked refresh token.")
        {
        }
    }
}