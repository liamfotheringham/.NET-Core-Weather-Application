using Xunit;

namespace Weather_Application_Tests.Shared.CustomWebApplicationFactory
{

    [CollectionDefinition("waf")]
    public class CustomWebApplicationCollection : ICollectionFixture<WebApplicationFixture>
    {
    }
}
