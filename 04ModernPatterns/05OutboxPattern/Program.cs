using _05OutboxPattern;
using _05OutboxPattern.Context;
using _05OutboxPattern.Features.Orders;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TS.MediatR;
using TS.Result;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfr => cfr.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("MyDb"));

builder.Services.AddHostedService<OrderBackgroundService>();

var app = builder.Build();

app.MapPost("/create-order",
    async (CreateOrderCommand request, ISender sender, CancellationToken cancellationToken) =>
    {
        var res = await sender.Send(request, cancellationToken);
        return Results.Ok(res);
    }).Produces<Result<string>>();

app.Run();
