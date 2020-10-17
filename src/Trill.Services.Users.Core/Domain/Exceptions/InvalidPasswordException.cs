namespace Trill.Services.Users.Core.Domain.Exceptions
{
    public class InvalidPasswordException : DomainException
    {
        public InvalidPasswordException() : base("Invalid password.")
        {
        }
    }
}