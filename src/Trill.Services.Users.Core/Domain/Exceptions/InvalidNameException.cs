namespace Trill.Services.Users.Core.Domain.Exceptions
{
    public class InvalidNameException : DomainException
    {
        public InvalidNameException(string name) : base($"Invalid name: {name}.")
        {
        }
    }
}