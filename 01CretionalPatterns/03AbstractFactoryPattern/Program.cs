using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Abstract Factory Pattern...");

ServiceCollection services = new();
#region Example 1
services.AddKeyedScoped<IFurnitureFactory, ClassicFurnitureFactory>(FurnitureTypeNames.Classic);
services.AddKeyedScoped<IFurnitureFactory, ModernFurnitureFactory>(FurnitureTypeNames.Modern);
services.AddKeyedScoped<IFurnitureFactory, OldTimesFurnitureFactory>(FurnitureTypeNames.OldTimes);
#endregion

#region Example 2
services.AddScoped<IRepository, ProductMongoDbRepository>();
services.AddScoped<IUnitOfWork, MongoDbUnitOfWork>();
services.AddScoped<ProductService>();
#endregion

using var srv = services.BuildServiceProvider();
#region Example 1
var furniture1 = srv.GetRequiredKeyedService<IFurnitureFactory>(FurnitureTypeNames.Classic);
//var furniture1 = FurnitureFactoryProvider.Create("modern");
furniture1.CreateChair();
furniture1.CreateChair();

var furniture2 = srv.GetRequiredKeyedService<IFurnitureFactory>(FurnitureTypeNames.Modern);
//var furniture2 = FurnitureFactoryProvider.Create("classic");
furniture2.CreateTable();
#endregion

#region Example 2
var productService = srv.GetRequiredService<ProductService>();
productService.Create();
#endregion

Console.ReadLine();

#region Example 1
interface IChair
{
}
interface ITable;

class ClassicChair : IChair
{
}

class ClassicTable : ITable;

class ModernChair : IChair
{
}
class ModernTable : ITable;

class OldTimesChair : IChair;
class OldTimesTable : ITable;
interface IFurnitureFactory
{
    IChair CreateChair();
    ITable CreateTable();
}

class ClassicFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ClassicChair();
    }

    public ITable CreateTable()
    {
        return new ClassicTable();
    }
}

class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ModernChair();
    }

    public ITable CreateTable()
    {
        return new ModernTable();
    }
}


class OldTimesFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new OldTimesChair();
    }

    public ITable CreateTable()
    {
        return new OldTimesTable();
    }
}

class FurnitureFactoryProvider
{
    public static IFurnitureFactory Create(string type)
    {
        switch (type)
        {
            case "modern": return new ModernFurnitureFactory();
            case "classic": return new ClassicFurnitureFactory();
            case "old-times": return new OldTimesFurnitureFactory();

            default:
                throw new ArgumentException("Invalid type");
        }
    }
}

class FurnitureTypeNames
{
    public static string Classic => "Classic";
    public static string Modern => "Modern";
    public static string OldTimes => "Old Times";
}
#endregion

#region Example 2
interface IRepository
{
    void Add();
}

interface IUnitOfWork
{
    void SaveChanges();
}
class ProductMSSQLRepository : IRepository
{
    public void Add() { }
}

class MSSQLUnitOfWork : IUnitOfWork
{
    public void SaveChanges() { }
}

class ProductMongoDbRepository : IRepository
{
    public void Add() { }
}

class MongoDbUnitOfWork : IUnitOfWork
{
    public void SaveChanges() { }
}

class ProductService
{
    public IRepository _repository;
    public IUnitOfWork _unitOfWork;

    public ProductService(IRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public void Create()
    {
        _repository.Add();
        _unitOfWork.SaveChanges();
    }
}
#endregion