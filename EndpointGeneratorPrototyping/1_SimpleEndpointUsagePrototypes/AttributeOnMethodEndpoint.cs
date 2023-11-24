namespace EndpointGeneratorPrototyping._1_SimpleEndpointUsagePrototypes;

internal static class AttributeOnMethodEndpoint
{
    [GetEndpoint("whatever/{id:Guid}")]
    public static Task<Guid> Handle(Guid id) => Task.FromResult(id);
}