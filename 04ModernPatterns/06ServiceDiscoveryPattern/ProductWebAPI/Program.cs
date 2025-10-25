using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConsulDiscoveryClient();

var app = builder.Build();

app.MapGet("/getall", () =>
{
    List<string> names = new()
    {
        "Elma",
        "Armut"
    };

    return names;
});

app.Run();
