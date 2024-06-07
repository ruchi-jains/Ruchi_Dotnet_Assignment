namespace demo_dependency_injection.Common
{
    public class Credentials
    {
        internal static readonly string databaseName = Environment.GetEnvironmentVariable("databaseName");
        internal static readonly string containerName = Environment.GetEnvironmentVariable("containerName");
        internal static readonly string CosmosEndpoint = Environment.GetEnvironmentVariable("cosmosUrl");
        internal static readonly string PrimaryKey = Environment.GetEnvironmentVariable("primaryKey");
    }
}
