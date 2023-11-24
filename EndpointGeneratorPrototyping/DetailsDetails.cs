namespace EndpointGeneratorPrototyping;

internal interface IConfiguredEndpoint
{
    static abstract void Configure(IEndpointConventionBuilder builder);
}

public interface IGetEndpoint
{
    static abstract string Route { get; }
}

public interface IGetEndpoint<in TRequest, out TResponse>
{
    static abstract string Route { get; }
    TResponse Handle(TRequest request);
}

public interface IDelegateEndpoint
{
    static abstract Delegate Handler { get; }
    static abstract HttpMethod Method { get; }
    static abstract string Route { get; }
}

public interface ISelfConfiguredEndpoint
{
    static abstract void Configure(IEndpointRouteBuilder builder);
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class GetEndpointAttribute : Attribute
{
    public GetEndpointAttribute(string route)
    {
        Route = route;
    }

    public string Route { get; }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class GetHandlerAttribute : Attribute
{
    public GetHandlerAttribute(string route)
    {
        Route = route;
    }

    public string Route { get; }
}

[AttributeUsage(AttributeTargets.Method)]
public sealed class EndpointHandlerAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Method)]
public sealed class EndpointConfigurationAttribute : Attribute
{
}

public class SomeService : ISomeService
{
    public Task<SomeResult> Get(Guid id)
    {
        return Task.FromResult(new SomeResult
        {
            Id = id
        });
    }
}

public interface ISomeService
{
    Task<SomeResult> Get(Guid id);
}

public sealed class SomeResult
{
    public required Guid Id { get; init; }
}