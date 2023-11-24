namespace EndpointGeneratorPrototyping.ConfiguredEndpointUsagePrototypes;

// this works but feels a bit boilerplatey, can remove the method by making specific interfaces
internal sealed class InterfaceEndpoint_Delegate : IDelegateEndpoint, IConfiguredEndpoint
{
    public static void Configure(IEndpointConventionBuilder builder) => builder
        .RequireAuthorization();

    public static string Route => "/something/{id:Guid}";
    public static Delegate Handler => Handle;
    public static HttpMethod Method => HttpMethod.Get;

    public static Task<Guid> Handle(Guid id) => Task.FromResult(id);
}