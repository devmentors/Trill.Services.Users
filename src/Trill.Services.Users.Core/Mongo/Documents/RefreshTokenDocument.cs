using System;
using Convey.Types;
using Trill.Services.Users.Core.Domain.Entities;

namespace Trill.Services.Users.Core.Mongo.Documents
{
    public class RefreshTokenDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RevokedAt { get; set; }

        public RefreshTokenDocument()
        {
        }

        public RefreshTokenDocument(RefreshToken refreshToken)
        {
            Id = refreshToken.Id;
            UserId = refreshToken.UserId;
            Token = refreshToken.Token;
            CreatedAt = refreshToken.CreatedAt;
            RevokedAt = refreshToken.RevokedAt;
        }

        public RefreshToken ToEntity() => new RefreshToken(Id, UserId, Token, CreatedAt, RevokedAt);
    }
}