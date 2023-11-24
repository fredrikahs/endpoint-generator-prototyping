namespace EndpointGeneratorPrototyping.ConfiguredEndpointUsagePrototypes;

// how do we identify the handler and configure methods? convention? another attribute?
// an interface for the configuration and convention for the handler? could add an analyzer if we're using convention
[GetEndpoint("whatever/{id:Guid}")]
internal static class AttributeOnClassEndpoint
{
    public static void Configure(IEndpointConventionBuilder builder) => builder
        .RequireAuthorization();

    public static Task<Guid> Handle(Guid id) => Task.FromResult(id);
}