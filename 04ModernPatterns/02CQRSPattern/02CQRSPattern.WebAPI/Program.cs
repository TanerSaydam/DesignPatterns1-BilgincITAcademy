using _02CQRSPattern.Application;
using TS.MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfr =>
{
    cfr.RegisterServicesFromAssembly(typeof(ProductCreateCommandRequest).Assembly);
});

var app = builder.Build();

app.MapPost("/create", async (ProductCreateCommandRequest request, ISender sender) =>
{
    await sender.Send(request);

    return Results.Ok();
});

app.Run();
