using Microsoft.Extensions.DependencyInjection;

namespace conti.sb;

public static class RegistrationExtensions
{
    public static IServiceCollection AddServiceBus(this IServiceCollection services)
    {
        return services;
    }
}
