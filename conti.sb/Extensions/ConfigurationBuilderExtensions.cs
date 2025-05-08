using Microsoft.Extensions.Configuration;

namespace conti.sb;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddEntityConfiguration(
        this IConfigurationBuilder builder)
    {
        var tempConfig = builder.Build();
        var connectionString =
            tempConfig.GetConnectionString("WidgetConnectionString");

        return builder.Add(new EntityConfigurationSource(connectionString));
    }

    public static IConfigurationBuilder AddFasterConfiguration(
        this IConfigurationBuilder builder)
    {
        var tempConfig = builder.Build();
        var connectionString =
            tempConfig.GetSection("FasterKv:SbConfigurations");

        return builder.Add(new EntityConfigurationSource(connectionString));
    }
}
