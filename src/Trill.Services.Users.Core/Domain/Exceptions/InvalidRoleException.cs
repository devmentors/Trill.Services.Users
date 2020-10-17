namespace Trill.Services.Users.Core.Domain.Exceptions
{
    public class InvalidRoleException : DomainException
    {
        public InvalidRoleException(string role) : base($"Invalid role: {role}.")
        {
        }
    }
}