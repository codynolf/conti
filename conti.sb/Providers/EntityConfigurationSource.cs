using Microsoft.Extensions.Configuration;

namespace conti.sb;

public class EntityConfigurationSource(
    string? connectionString) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new EntityConfigurationProvider(connectionString);
}
