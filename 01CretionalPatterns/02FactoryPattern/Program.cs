using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Factory Pattern...");

ServiceCollection services = new();
services.AddKeyedScoped<INotification, SmsNotification>(NotificationEnum.Sms);
services.AddKeyedScoped<INotification, EmailNotification>(NotificationEnum.Email);
services.AddKeyedScoped<INotification, CloudeNotification>(NotificationEnum.Cloude);
services.AddKeyedScoped<INotification, WhatsappNotification>(NotificationEnum.WP);
services.AddScoped<Test>();

using var srv = services.BuildServiceProvider();
srv.GetRequiredService<Test>();
INotification? smsNotification = srv.GetKeyedService<INotification>(NotificationEnum.Sms); //New version
INotification emailNotification = srv.GetRequiredKeyedService<INotification>(NotificationEnum.Email); //New version

//INotification notification = NotificationFactory.Create(NotificationEnum.Sms); //Old version
if (smsNotification is not null)
{
    smsNotification.Send("Hello world");
}
emailNotification.Send("Hello world");

Console.ReadLine();

interface INotification
{
    void Send(string message);
}
class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Sended email: {0}", message);
    }
}

class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Sended sms: {0}", message);
    }
}

class WhatsappNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Sended whatsapp: {0}", message);
    }
}

class CloudeNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Sended cloude: {0}", message);
    }
}

#region 1994 deki teorinin pratik çözümü
class NotificationFactory
{
    public static INotification Create(NotificationEnum type)
    {
        switch (type)
        {
            case NotificationEnum.Email: return new EmailNotification();
            case NotificationEnum.Sms: return new SmsNotification();
            case NotificationEnum.WP: return new WhatsappNotification();
            case NotificationEnum.Cloude: return new CloudeNotification();
            default:
                throw new ArgumentException("Invalid type");
        }
    }
}

enum NotificationEnum
{
    Email = 0,
    Sms,
    WP,
    Cloude
}
#endregion

class Test
{
    public Test([FromKeyedServices(NotificationEnum.Email)] INotification notification)
    {

    }
}