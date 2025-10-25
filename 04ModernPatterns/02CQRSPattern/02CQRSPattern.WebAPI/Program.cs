using _02CQRSPattern.Application.Behaviors;
using _02CQRSPattern.Application.Products;
using _02CQRSPattern.Domain.Events;
using TS.MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfr =>
{
    cfr.RegisterServicesFromAssemblies(typeof(ProductCreateCommand).Assembly, typeof(ProductCreateDomainEvent).Assembly);
    cfr.AddOpenBehavior(typeof(ValidateBehavior<>));
    cfr.AddOpenBehavior(typeof(ValidateBehavior<,>));
});

var app = builder.Build();

app.MapPost("/create", async (ProductCreateCommand request, ISender sender) =>
{
    await sender.Send(request);
    return Results.Ok();
});

app.Run(); // 10:30 görüþelim