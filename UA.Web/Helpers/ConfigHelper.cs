namespace UA.Web.Helpers;

public static class ConfigHelper
{
    public static IServiceCollection AddConfig<TConfigInterface, TConfig>(
        this IServiceCollection services,
        IConfigurationSection configuration)
        where TConfig : TConfigInterface, new()
    {
        var config = new TConfig();

        configuration.Bind(config);

        services.Add(new ServiceDescriptor(
            serviceType: typeof(TConfigInterface),
            instance: config));

        return services;
    }
}