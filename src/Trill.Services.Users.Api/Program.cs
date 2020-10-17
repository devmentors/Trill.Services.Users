using System.Threading.Tasks;
using Convey;
using Convey.Logging;
using Convey.Secrets.Vault;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Trill.Services.Users.Core;
using Trill.Services.Users.Core.Commands;
using Trill.Services.Users.Core.DTO;
using Trill.Services.Users.Core.Queries;
using Trill.Services.Users.Core.Services;

namespace Trill.Services.Users.Api
{
    internal static class Program
    {
        public static async Task Main(string[] args)
            => await CreateHostBuilder(args)
                .Build()
                .RunAsync();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder
                    .ConfigureServices(services => services
                        .AddConvey()
                        .AddWebApi()
                        .AddCore()
                        .Build())
                    .Configure(app => app
                        .UseCore()
                        .UseDispatcherEndpoints(endpoints => endpoints
                            .Get("", ctx => ctx.GetAppName())
                            .Post<SignIn>("sign-in", afterDispatch: (cmd, ctx) =>
                            {
                                var auth = ctx.RequestServices.GetRequiredService<ITokenStorage>().Get(cmd.Id);
                                return ctx.Response.WriteJsonAsync(auth);
                            })
                            .Post<CreateUser>("sign-up")
                            .Post<RevokeAccessToken>("access-tokens/revoke")
                            .Post<UseRefreshToken>("refresh-tokens/use", afterDispatch: (cmd, ctx) =>
                            {
                                var auth = ctx.RequestServices.GetRequiredService<ITokenStorage>().Get(cmd.Id);
                                return ctx.Response.WriteJsonAsync(auth);
                            })
                            .Post<RevokeRefreshToken>("refresh-tokens/revoke")
                            .Get<GetUser, UserDetailsDto>("users/{userId:guid}")
                            .Get<BrowseUsers, PagedDto<UserDto>>("users")
                            .Post<FollowUser>("users/{userId:guid}/following/{followeeId:guid}")
                            .Delete<UnfollowUser>("users/{userId:guid}/following/{followeeId:guid}")
                            .Put<LockUser>("users/{userId:guid}/lock")
                            .Put<UnlockUser>("users/{userId:guid}/unlock")
                            .Post<AddFunds>("users/{userId:guid}/funds")
                            .Post<ChargeFunds>("users/{userId:guid}/funds/charge"))))
                .UseLogging()
                .UseVault();
    }
}
