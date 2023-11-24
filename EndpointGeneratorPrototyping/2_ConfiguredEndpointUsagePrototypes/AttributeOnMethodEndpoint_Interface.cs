namespace EndpointGeneratorPrototyping.ConfiguredEndpointUsagePrototypes;

// this would require some analyzer to verify only one attribute is used for the class
// alternatively all handlers would receive the same configuration,
// would likely set a bad precedent where you write multiple endpoints in one class and then have to refactor them
// and copy pasta the configuration as soon as there's a difference between them
// could use either ctor or handler injection
internal class AttributeOnMethodInterfaceEndpoint : IConfiguredEndpoint
{
    public static void Configure(IEndpointConventionBuilder builder) => builder
        .RequireAuthorization();

    [GetHandler("whatever/{id:Guid}")]
    public static Task<Guid> Handle(Guid id) => Task.FromResult(id);
}