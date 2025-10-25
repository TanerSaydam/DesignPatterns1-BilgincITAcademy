using _04ResultPattern;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<ErrorHandler>().AddProblemDetails();

builder.Services.AddScoped<ProductService>();

var app = builder.Build();

app.UseExceptionHandler();

app.MapGet("/", () => Result<string>.Succeed("Hello World!"));
app.MapGet("/create", (ProductService productService) => productService.Create());
app.MapGet("/update", () => Result<string>.Succeed("Update is successful"));
app.MapGet("/delete", () => Result<string>.Succeed("Delete is successful"));
app.MapGet("/getall", () =>
{
    List<string> names = new()
    {
        "Taner","Ahmet"
    };

    return Result<List<string>>.Succeed(names);
});
app.MapGet("/error1", () => Result<string>.Failed("Product not found!"));
app.MapGet("/error2", () =>
{
    throw new ArgumentException("bla bla");
});

app.Run();

class Result<T>
{
    private Result()
    {
    }
    private Result(T data)
    {
        Data = data;
        IsSuccessful = true;
    }

    private Result(string errorMessage, bool isSuccessful = false)
    {
        ErrorMessage = errorMessage;
        IsSuccessful = false;
    }
    public T? Data { get; private set; }
    public string? ErrorMessage { get; private set; }
    public bool IsSuccessful { get; private set; }

    public static Result<T> Succeed(T data)
    {
        return new Result<T>(data);
    }

    public static Result<T> Failed(string message)
    {
        return new Result<T>(message, false);
    }

    public static implicit operator Result<T>(T data)
    {
        return new Result<T>(data);
    }
}


class ProductService
{
    public Result<string> Create()
    {
        //if (false)
        //{
        //    return Result<string>.Failed("Failed");
        //}
        return "succeed";
    }
}
