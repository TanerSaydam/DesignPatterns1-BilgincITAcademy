Console.WriteLine("Command Pattern...");

var createHandler = new ProductCreateCommandHandler();
var createRequest = new ProductCreateCommandRequest("Bilgisayar", 50);
createHandler.Handle(createRequest);

Console.ReadLine();

record ProductCreateCommandRequest(string name, decimal price);
record ProductCreateCommandResponse(string message);
class ProductCreateCommandHandler
{
    public ProductCreateCommandResponse Handle(ProductCreateCommandRequest request)
    {
        //işlemi

        return new("Is successful");
    }
}

record ProductUpdateCommandRequest(Guid id, string name, decimal price);
record ProductUpdateCommandResponse(string message);
class ProductUpdateCommandHandler
{
    public ProductUpdateCommandResponse Handle(ProductUpdateCommandRequest request)
    {
        //işlemi
        return new("Is successful");
    }
}

//CQRS pattern // Command Query Responsibility Segregation