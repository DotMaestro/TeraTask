namespace TransferService.Tests.Unit
{
    [CollectionDefinition("TransferCollection")]
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
