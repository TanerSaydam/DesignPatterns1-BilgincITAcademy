using Mapster;

Console.WriteLine("Prototype Pattern...");

Product product1 = new();
product1.Name = "Bilgisayar";
product1.Price = 50000;
product1.Stock = 15;

//Product product2 = (Product)product1.Clone();
Product product2 = product1.Adapt<Product>();
product2.Name = "Laptop";

Console.ReadLine();

class Product : ICloneable
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public object Clone()
    {
        return new Product()
        {
            Name = Name,
            Price = Price,
            Stock = Stock,
        };
    }
}
