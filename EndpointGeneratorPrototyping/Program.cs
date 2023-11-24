using EndpointGeneratorPrototyping;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ISomeService, SomeService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();