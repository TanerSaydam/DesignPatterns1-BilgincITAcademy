using _02CQRSPattern.Application.Behaviors;
using _02CQRSPattern.Application.Products;
using _02CQRSPattern.Domain.Events;
using _02CQRSPattern.WebAPI;
using Microsoft.EntityFrameworkCore;
using TS.MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfr =>
{
    cfr.RegisterServicesFromAssemblies(typeof(ProductCreateCommand).Assembly, typeof(ProductCreateDomainEvent).Assembly);
    cfr.AddOpenBehavior(typeof(ValidateBehavior<>));
    cfr.AddOpenBehavior(typeof(ValidateBehavior<,>));
});

builder.Services.AddDbContext<DbContext>();

//Service Registration
builder.Services.AddScoped<Test>();
builder.Services.AddTransient<Test2>();
builder.Services.AddHostedService<MyBackground>();

//builder.Services.Scan(x => x
//.FromAssemblies(Assembly.GetExecutingAssembly())
//.AddClasses(publicOnly: false)
//.UsingRegistrationStrategy(RegistrationStrategy.Skip)
//.AsImplementedInterfaces()
//.WithScopedLifetime()
//);

//builder.Services.AddTransient<IProductService, ProductService>();
//builder.Services.AddTransient<ICategoryService, CategoryService>();

var app = builder.Build();

app.MapPost("/create", async (ProductCreateCommand request, ISender sender) =>
{
    //var iface = typeof(IRequestHandler<ProductCreateCommand, ProductCreateCommandResponse>);
    //var assembly = typeof(ProductCreateCommand).Assembly;
    //var res = assembly.GetTypes().Where(p => iface.IsAssignableFrom(p))
    //.ToList();

    await sender.Send(request);
    return Results.Ok();
});

app.MapGet("/test", (Test test, HttpContext httpContext) =>
{
    test.Number = 25;
    var test2 = httpContext.RequestServices.GetRequiredService<Test2>();
    Console.WriteLine(test2.Test2Number);
    return Results.Ok();
});

app.Run();

public class Test
{
    public int Number { get; set; }
}

public class Test2
{
    public int Test2Number { get; set; }
    public Test2(Test test)
    {
        Test2Number = test.Number;
    }
}

interface IProductService { };

class ProductService : IProductService;

interface ICategoryService { };

class CategoryService : ICategoryService;