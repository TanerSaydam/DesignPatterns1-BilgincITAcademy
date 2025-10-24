Console.WriteLine("Facade Pattern...");

var shop = new ShopFacade();
shop.PlaceOrder("Bilgisayar", "Taner Saydam", "1111", "Kayseri");

Console.ReadLine();

class InventoryService
{
    public bool IsAvailable(string productName)
    {
        Console.WriteLine("[Inventory] Checking product {0} stock for availability...", productName);
        return true;
    }
}

class PaymentService
{
    public bool ProccessPayment(string customer, string cardNumber)
    {
        Console.WriteLine("[Payment] Processing payment for customer: {0}, card number: {1}", customer, cardNumber);
        return true;
    }
}

class DeliveryService
{
    public void ScheduleDelivery(string product, string address)
    {
        Console.WriteLine("[Delivery] Scheduling delivery for {0} to {1}", product, address);
    }
}

class ShopFacade
{
    InventoryService inventoryService = new();
    PaymentService paymentService = new();
    DeliveryService deliveryService = new();
    public void PlaceOrder(string product, string customer, string cardNumber, string address)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- Processing Order ---");
        Console.ForegroundColor = ConsoleColor.White;
        var haveProduct = inventoryService.IsAvailable(product);
        if (!haveProduct)
        {
            Console.WriteLine("Product {0} is out of stock", product);
            return;
        }

        var paymentResult = paymentService.ProccessPayment(customer, cardNumber);
        if (!paymentResult)
        {
            Console.WriteLine("Payment failed!");
            return;
        }

        deliveryService.ScheduleDelivery(product, address);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Order completed successfuly");
    }
}