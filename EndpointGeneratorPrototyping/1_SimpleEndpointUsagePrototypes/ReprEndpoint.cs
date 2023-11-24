namespace EndpointGeneratorPrototyping._1_SimpleEndpointUsagePrototypes;

// This would work and is quite easy to grasp
// it's not very flexible as it requires request classes if we're dealing with more than one parameter
// has to use constructor injection since the handler is included in the interface
internal sealed class ReprEndpoint : IGetEndpoint<Guid, Task<SomeResult>>
{
    private readonly ISomeService _someService;

    public ReprEndpoint(ISomeService someService)
    {
        _someService = someService;
    }

    public static string Route => "/whatever/{id:Guid}";

    public Task<SomeResult> Handle(Guid id) => _someService.Get(id);
}