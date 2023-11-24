namespace EndpointGeneratorPrototyping.ConfiguredEndpointUsagePrototypes;

[GetEndpoint("whatever/{id:Guid}")]
internal static class AttributeOnClassConventionEndpoint
{
    public static void Configure(IEndpointConventionBuilder builder) => builder
        .RequireAuthorization();

    public static Task<Guid> Handle(Guid id) => Task.FromResult(id);
}