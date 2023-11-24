namespace EndpointGeneratorPrototyping._1_SimpleEndpointUsagePrototypes;

internal sealed class InterfaceEndpoint : IGetEndpoint
{
    public static string Route => "/something/{id:Guid}";

    // how is this identified? by name convention? cant include it in the interface because we don't know the signature
    public static Task<Guid> Handle(Guid id) => Task.FromResult(id);
}