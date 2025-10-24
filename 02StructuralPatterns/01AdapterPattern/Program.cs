Console.WriteLine("Adapter Pattern...");

INotification service = new EmailNotificationService();
service.Send("tanersaydam@gmail.com", "Hello world");

INotification smsService = new SmsAdapter(new SmsNotificationService());
smsService.Send("46546", "message");

Console.ReadLine();

interface INotification
{
    void Send(string to, string body);
}

class EmailNotificationService : INotification
{
    public void Send(string to, string body)
    {
        Console.WriteLine("[Email] to: {0}, body: {1}", to, body);
    }
}

class SmsNotificationService
{
    public void SendSms(string phoneNumber, string message)
    {
        Console.WriteLine("[Sms] phoneNumber: {0}, message: {1}", phoneNumber, message);
    }
}

class SmsAdapter(SmsNotificationService smsService) : INotification
{
    public void Send(string to, string body)
    {
        smsService.SendSms(to, body);
    }
}