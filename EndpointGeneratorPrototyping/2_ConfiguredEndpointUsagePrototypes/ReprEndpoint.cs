namespace EndpointGeneratorPrototyping.ConfiguredEndpointUsagePrototypes;

// This would work and is quite easy to grasp
// it's not very flexible as it requires request classes if we're dealing with more than one parameter
internal sealed class ReprEndpoint : IGetEndpoint<Guid, Task<SomeResult>>, IConfiguredEndpoint
{
    private readonly ISomeService _someService;

    public ReprEndpoint(ISomeService someService)
    {
        _someService = someService;
    }

    public static void Configure(IEndpointConventionBuilder builder) => builder
        .RequireAuthorization();

    public static string Route => "/whatever/{id:Guid}";

    public Task<SomeResult> Handle(Guid id) => _someService.Get(id);
}