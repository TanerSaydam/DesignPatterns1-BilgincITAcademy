Console.WriteLine("Decorator Pattern...");

IMailService service = new MailService();
service = new LoggingMailDecorator(service);
//service = new SignatureMailDecorator(service, "\nBest Regards.\nTaner Saydam");

service.Send("tanersaydam@gmail.com", "Hello", "Hello world");

Console.ReadLine();

interface IMailService
{
    void Send(string to, string subject, string body);
}

class MailService : IMailService
{
    public void Send(string to, string subject, string body)
    {
        Console.WriteLine("[MailServide] Sending email...\nTo: {0}\nSubject: {1}\nBody: {2}", to, subject, body);
    }
}

#region Decorator Pattern
abstract class MailDecorator : IMailService
{
    protected readonly IMailService _service;

    protected MailDecorator(IMailService service)
    {
        _service = service;
    }

    public abstract void Send(string to, string subject, string body);
}

class LoggingMailDecorator : MailDecorator
{
    public LoggingMailDecorator(IMailService service) : base(service)
    {
    }

    public override void Send(string to, string subject, string body)
    {
        Console.WriteLine("[LOG] Sending email...\nTo: {0}\nSubject: {1}\nBody: {2}", to, subject, body);
        _service.Send(to, subject, body);
    }
}

class SignatureMailDecorator : MailDecorator
{
    string _signature;
    public SignatureMailDecorator(IMailService service, string signature) : base(service)
    {
        _signature = signature;
    }

    public override void Send(string to, string subject, string body)
    {
        body += " " + _signature;
        _service.Send(to, subject, body);
    }
}
#endregion

