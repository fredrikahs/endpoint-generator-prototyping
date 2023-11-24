namespace EndpointGeneratorPrototyping._3_EndpointGroupPrototypes;

internal sealed class SomeGroup : IEndpointGroup
{
    public static string RoutePrefix => "somegroup";

    public static void Configure(RouteGroupBuilder group) => group
        .RequireAuthorization();
}

public class InterfaceGroupedEndpoint_1 : IConfiguredEndpoint, IGroupedEndpoint<SomeGroup>
{
    public static void Configure(IEndpointConventionBuilder builder) => builder
        .WithSummary("summary 1");

    [GetEndpoint("{id:Guid}")]
    public static Task<Guid> Handle(Guid id) => Task.FromResult(id);
}

public class InterfaceGroupedEndpoint_2 : IConfiguredEndpoint, IGroupedEndpoint<SomeGroup>
{
    public static void Configure(IEndpointConventionBuilder builder) => builder
        .WithSummary("summary 2");

    [GetEndpoint("2/{id:Guid}")]
    public static Task<Guid> Handle(Guid id) => Task.FromResult(id);
}

internal interface IGroupedEndpoint<TGroup> where TGroup : IEndpointGroup;

internal interface IEndpointGroup
{
    static abstract string RoutePrefix { get; }
    static abstract void Configure(RouteGroupBuilder group);
}