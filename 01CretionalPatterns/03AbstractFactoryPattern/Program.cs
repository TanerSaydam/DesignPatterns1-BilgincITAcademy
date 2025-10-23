Console.WriteLine("Abstract Factory Pattern...");

var furniture1 = FurnitureFactoryProvider.Create("modern");
furniture1.CreateChair();
furniture1.CreateChair();
var furniture2 = FurnitureFactoryProvider.Create("classic");
furniture2.CreateTable();

Console.ReadLine();

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