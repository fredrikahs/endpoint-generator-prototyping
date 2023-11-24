namespace EndpointGeneratorPrototyping.ConfiguredEndpointUsagePrototypes;

internal static class AttributeOnMethodEndpoint
{
    // found by convention?
    public static void Configure(IEndpointConventionBuilder builder) => builder
        .RequireAuthorization();

    [GetEndpoint("whatever/{id:Guid}")]
    public static Task<Guid> Handle(Guid id) => Task.FromResult(id);
}