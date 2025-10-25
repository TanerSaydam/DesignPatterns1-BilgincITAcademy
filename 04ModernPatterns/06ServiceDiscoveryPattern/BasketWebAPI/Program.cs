using Steeltoe.Discovery.Consul;
using TS.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConsulDiscoveryClient();

builder.Services.AddHttpClient();
builder.Services.AddEndpoint();

var app = builder.Build();

app.MapEndpoints();

app.Run();
