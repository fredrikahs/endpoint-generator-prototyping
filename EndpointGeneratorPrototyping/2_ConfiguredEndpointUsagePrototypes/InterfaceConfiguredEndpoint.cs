namespace EndpointGeneratorPrototyping.ConfiguredEndpointUsagePrototypes;

internal sealed class InterfaceConfiguredEndpoint : IGetEndpoint, IConfiguredEndpoint
{
    public static void Configure(IEndpointConventionBuilder builder) => builder
        .RequireAuthorization();

    public static string Route => "/something/{id:Guid}";

    public static Task<Guid> Handle(Guid id) => Task.FromResult(id);
}