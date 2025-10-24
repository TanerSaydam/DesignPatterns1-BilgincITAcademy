using Microsoft.AspNetCore.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<TestMiddleware>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.Use((context, next) =>
{
    return next(context);
});

app.UseCors();

app.Use((context, next) =>
{
    return next(context);
});

app.MapControllers();

app.UseMiddleware<TestMiddleware>();

app.Run();


class TestMiddleware : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

        return next(context);
    }
}

class MyValidationAttribute : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("Çalýþýktan sonra");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("Uygulama çalýþmadan önce");
    }
}