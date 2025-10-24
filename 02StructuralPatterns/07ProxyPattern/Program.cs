Console.WriteLine("Proxy Pattern...");

ProductProxy productProxy = new();
Product product = new("Bilgisayar", 15000);
productProxy.Create(product);

Console.ReadLine();

record Product(
    string Name,
    decimal Price); //14:19 başlayacağız

class ProductRepository
{
    public void Create(Product product)
    {
        //db ye kaydet
        Console.WriteLine("Product create is successful!");
    }
}

class ProductProxy
{
    ProductRepository productRepository = new();
    public void Create(Product product)
    {
        if (product.Name.Length <= 2)
        {
            throw new ArgumentException("Product name must be greater than 2 words");
        }
        productRepository.Create(product);
    }
}
