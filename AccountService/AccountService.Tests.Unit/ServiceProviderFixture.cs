namespace AccountService.Tests.Unit
{
    [CollectionDefinition("MyCollection")]
    public class TestCollectionFixture : ICollectionFixture<ServiceProviderFixture>
    {

    }

    public class ServiceProviderFixture
    {
        public IServiceProvider ServiceProvider { get; }
        public ServiceProviderFixture()
        {
            ServiceProvider = TestStartUp.ConfigureServices();
        }
    }
}
