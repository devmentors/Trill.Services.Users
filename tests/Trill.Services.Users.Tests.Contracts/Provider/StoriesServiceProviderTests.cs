using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Pactify;
using Trill.Services._UsersTests.Contracts.Fixtures;
using Trill.Services.Users.Api;
using Trill.Services.Users.Core.Mongo.Documents;
using Xunit;

namespace Trill.Services.Users.Tests.Contracts.Provider
{
    public class StoriesServiceProviderTests : IClassFixture<WebApplicationFactory<Program>>, IDisposable
    {

        [Fact]
        public async Task Pact_Should_Be_Verified()
        {
            await _mongoDbFixture.InsertAsync(User);
            
           
        }

        #region ARRANGE

        private readonly UserDocument User = new()
        {
            Id =  new Guid("c68a24ea-384a-4fdc-99ce-8c9a28feac64"),
            Name = "Product",
            CreatedAt = DateTime.Now
        };
        
        private readonly MongoDbFixture<UserDocument, Guid> _mongoDbFixture;
        private readonly HttpClient _httpClient;
        private readonly WebApplicationFactory<Program> _factory;
        private bool _disposed = false;

        public StoriesServiceProviderTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _mongoDbFixture = new MongoDbFixture<UserDocument, Guid>("trill-users-service", "users");
            var testServer = factory.Server;
            testServer.AllowSynchronousIO = true;
            _httpClient = testServer.CreateClient();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _mongoDbFixture.Dispose();
                    _factory.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}