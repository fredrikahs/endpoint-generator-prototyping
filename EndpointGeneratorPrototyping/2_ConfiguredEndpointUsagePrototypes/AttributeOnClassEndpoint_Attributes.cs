namespace EndpointGeneratorPrototyping._2_ConfiguredEndpointUsagePrototypes;

[GetEndpoint("whatever/{id:Guid}")]
internal class AttributeOnClassAttributesEndpoint
{
    [EndpointConfiguration]
    public static void SomeConfiguration(IEndpointConventionBuilder builder) => builder
        .RequireAuthorization();

    [EndpointHandler]
    public static Task<Guid> SomeHandler(Guid id) => Task.FromResult(id);
}