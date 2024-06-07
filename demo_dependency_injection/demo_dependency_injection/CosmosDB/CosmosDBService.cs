using Microsoft.Azure.Cosmos;
using demo_dependency_injection.Common;
using demo_dependency_injection.Entities;
namespace demo_dependency_injection.CosmosDB
{
    public class CosmosDBService : ICosmosDBService
    {
        public CosmosClient _cosmosClient;
        private readonly Container _container;

        public CosmosDBService()
        {
            _cosmosClient = new CosmosClient(Credentials.CosmosEndpoint, Credentials.PrimaryKey);
            _container = _cosmosClient.GetContainer(Credentials.databaseName, Credentials.containerName);
        }
        public async Task<DemoEntity> AddDemo(DemoEntity demo)
        {
            var response = await _container.CreateItemAsync(demo);
            return demo;
        }
    }
}
