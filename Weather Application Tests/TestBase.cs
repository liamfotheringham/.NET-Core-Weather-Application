using System;
using System.Net.Http;
using System.Threading.Tasks;
using Weather_Application_Tests.Shared.CustomWebApplicationFactory;
using Xunit;

namespace Weather_Application_Tests.Shared.CustomWebApplicationFactory
{
    public class TestBase : IAsyncLifetime
    {
        protected readonly CustomWebApplicationFactory Factory = null!;

        public TestBase(CustomWebApplicationFactory factory)
        {
            Factory = factory;
        }

        public virtual async Task InitializeAsync()
        {
            await Factory.ResetState();
        }

        public virtual Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
