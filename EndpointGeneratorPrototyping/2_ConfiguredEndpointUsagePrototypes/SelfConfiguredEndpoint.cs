using System.Reflection;

namespace EndpointGeneratorPrototyping.ConfiguredEndpointUsagePrototypes;

// this would be very easy to implement and would work, but the win isn't really that big
// the endpoint could be registered in DI and the handler made non static if we prefer constructor injection
internal sealed class SelfConfiguredEndpoint : ISelfConfiguredEndpoint
{
    public static void Configure(IEndpointRouteBuilder builder) => builder
        .MapGet("whatever/{id:Guid}", SomeHandler)
        .RequireAuthorization();

    private static Task<SomeResult> SomeHandler(ISomeService someService, Guid id) => someService.Get(id);
}

// some simple reflection would be enough to register all endpoints, a source gen would unmagickify the registration
internal static class SelfConfiguredEndpointExtensions
{
    public static IEndpointRouteBuilder AddSelfConfiguredEndpoints(this IEndpointRouteBuilder builder, Assembly assembly)
    {
        var endpointTypes = assembly.GetTypes()
            .Where(t => !t.IsAbstract && HasInterface(t, typeof(ISelfConfiguredEndpoint)));

        foreach (var endpointType in endpointTypes)
        {
            var method = endpointType.GetMethod(nameof(ISelfConfiguredEndpoint.Configure))!;
            method.Invoke(null, [builder]);
        }

        return builder;
    }

    private static bool HasInterface(Type type, Type interfaceType) => type
        .GetInterfaces()
        .Contains(interfaceType);
}