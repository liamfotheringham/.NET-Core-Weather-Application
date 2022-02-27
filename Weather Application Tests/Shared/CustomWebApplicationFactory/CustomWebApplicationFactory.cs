using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using Respawn.Graph;
using System;
using System.Threading.Tasks;

namespace Weather_Application_Tests.Shared.CustomWebApplicationFactory
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        private Checkpoint _checkpoint = null!;

        public async Task ResetState()
        {
            var configuration = GetRequiredScopedService<IConfiguration>();

            await _checkpoint.Reset(configuration.GetConnectionString("DefaultConnection"));
        }

        public T GetRequiredScopedService<T>() where T : notnull
        {
            return Services.CreateScope().ServiceProvider.GetRequiredService<T>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development");
            builder.ConfigureServices(services => { });

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] {
                   new Table("__EFMigrationsHistory"),
                   new Table("TodoStatus"),
                },
            };
        }

        public Task CreateHttpClientAuthenticatedAsUser(string username, string password)
        {
            throw new NotImplementedException("In progress");
        }
    }
}
