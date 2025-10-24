using Microsoft.Extensions.Caching.Memory;

Console.WriteLine("Flyweight Pattern...");

var forest = new Forest();
forest.PlantTree(5, 10, "Çam", "Kırmızı", "cam.jpg");
forest.PlantTree(15, 20, "Kavak", "Yeşil", "kavak.jpg");
forest.PlantTree(20, 30, "Elma", "Mavi", "elma.jpg");
forest.PlantTree(15, 20, "Kavak", "Yeşil", "kavak.jpg");
forest.PlantTree(15, 20, "Kavak", "Yeşil", "kavak.jpg");
forest.PlantTree(5, 10, "Çam", "Kırmızı", "cam.jpg");

forest.Draw();

Console.ReadLine();

class TreeType
{
    public TreeType(string name, string color, string texture)
    {
        Name = name;
        Color = color;
        Texture = texture;
    }

    public string Name { get; set; }
    public string Color { get; set; }
    public string Texture { get; set; }

    public void Draw(int x, int y)
    {
        Console.WriteLine("Draw {0} at ({1}, {2}) with Color={3}, Texture={4}", Name, x, y, Color, Texture);
    }
}

class Tree
{
    public Tree(int x, int y, TreeType treeType)
    {
        X = x;
        Y = y;
        TreeType = treeType;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public TreeType TreeType { get; set; }

    public void Draw() => TreeType.Draw(X, Y);
}

class TreeFactory
{
    private static readonly Dictionary<string, TreeType> _cache = new();
    public static TreeType GetTreeType(string name, string color, string texture)
    {
        string key = $"{name}|{color}|{texture}";
        if (_cache.TryGetValue(key, out var type))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--{0} added from cache", name);
            Console.ForegroundColor = ConsoleColor.White;
            return type;
        }

        type = new TreeType(name, color, texture);
        _cache.Add(key, type);
        return type;
    }
}

class Forest
{
    public List<Tree> trees = new();
    MemoryCache cache = new(new MemoryCacheOptions());
    public void PlantTree(int x, int y, string name, string color, string texture)
    {
        string key = $"{name}|{color}|{texture}";
        TreeType? type = (TreeType?)cache.Get(key);
        if (type is null)
        {
            type = new TreeType(name, color, texture);
            cache.Set(key, type);
        }
        else
        {
            Console.WriteLine("--{0} added from cache", name);
        }
        var tree = new Tree(x, y, type);
        trees.Add(tree);
    }

    public void Draw()
    {
        foreach (var item in trees)
        {
            item.Draw();
        }
    }
}