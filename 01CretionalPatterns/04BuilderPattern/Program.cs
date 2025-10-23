using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Builder Pattern...");

ServiceCollection services = new();
#region Example 1
services.AddScoped<IHouseBuilder, HouseBuilder>();
#endregion

using var srv = services.BuildServiceProvider();
#region Example 1
IHouseBuilder houseBuilder = srv.GetRequiredService<IHouseBuilder>();

House house1 = houseBuilder
    .WindowCount(5)
    .DoorCount(2)
    .Build();

House house2 = houseBuilder
    .WindowCount(3)
    .DoorCount(1)
    .HaveGarden()
    .Build();

House house3 = houseBuilder
    .WindowCount(4)
    .DoorCount(1)
    .HaveGarden()
    .HavePool()
    .Build();

//House houseExample = new(windowCount: 5, doorCount: 4, haveGarden: true, havePool: false);
#endregion

Console.ReadLine();

#region Example 1
class House
{
    public House(int windowCount, int doorCount, bool haveGarden, bool havePool)
    {
        WindowCount = windowCount;
        DoorCount = doorCount;
        HaveGarden = haveGarden;
        HavePool = havePool;
    }

    public int WindowCount { get; set; }
    public int DoorCount { get; set; }
    public bool HaveGarden { get; set; }
    public bool HavePool { get; set; }
}

interface IHouseBuilder
{
    HouseBuilder WindowCount(int count);
    HouseBuilder DoorCount(int count);
    HouseBuilder HaveGarden();
    HouseBuilder HavePool();
    House Build();
}

class HouseBuilder : IHouseBuilder
{
    int _windowCount;
    int _doorCount;
    bool _haveGarden;
    bool _havePool;
    public HouseBuilder WindowCount(int count)
    {
        _windowCount = count;
        return this;
    }

    public HouseBuilder DoorCount(int count)
    {
        _doorCount = count;
        return this;
    }

    public HouseBuilder HaveGarden()
    {
        _haveGarden = true;
        return this;
    }

    public HouseBuilder HavePool()
    {
        _havePool = true;
        return this;
    }
    public House Build()
    {
        return new House(_windowCount, _doorCount, _haveGarden, _havePool);
    }
}
#endregion