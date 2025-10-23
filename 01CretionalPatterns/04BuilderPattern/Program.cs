using FluentEmail.Core;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Builder Pattern...");

ServiceCollection services = new();
services
    .AddFluentEmail("info@ts.com")
    .AddSmtpSender("localhost", 25);

#region Example 1
services.AddScoped<IHouseBuilder, HouseBuilder>();
#endregion

using var srv = services.BuildServiceProvider();

var fluentEmail = srv.GetRequiredService<IFluentEmail>();

fluentEmail
    .To("tanersaydam@gmail.com")
    .Subject("Test")
    .Body("<h1>Hello world</h1>", true)
    .Send();

#region Example 1
IHouseBuilder houseBuilder1 = srv.GetRequiredService<IHouseBuilder>();
House house1 = houseBuilder1
    .WindowCount(5)
    .DoorCount(2)
    .Build();

IHouseBuilder houseBuilder2 = srv.GetRequiredService<IHouseBuilder>();
House house2 = houseBuilder2
    .WindowCount(3)
    .DoorCount(1)
    .HaveGarden()
    .Build();

IHouseBuilder houseBuilder3 = srv.GetRequiredService<IHouseBuilder>();
House house3 = houseBuilder3
    .WindowCount(4)
    .DoorCount(1)
    .HaveGarden()
    .HavePool()
    .Build();

//House houseExample = new(windowCount: 5, doorCount: 4, haveGarden: true, havePool: false);
#endregion

#region Example 2
MailService mailService = new();
mailService
    .WithFrom("tanersaydam@gmail.com")
    .WithTo("info@saydam.com")
    .WithSubject("Test")
    .WithBody("Hello world")
    .Send();
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
    IHouseBuilder WindowCount(int count);
    IHouseBuilder DoorCount(int count);
    IHouseBuilder HaveGarden();
    IHouseBuilder HavePool();
    House Build();
}

class HouseBuilder : IHouseBuilder
{
    int _windowCount;
    int _doorCount;
    bool _haveGarden; //false
    bool _havePool;//false
    public IHouseBuilder WindowCount(int count)
    {
        _windowCount = count;
        return this;
    }

    public IHouseBuilder DoorCount(int count)
    {
        _doorCount = count;
        return this;
    }

    public IHouseBuilder HaveGarden()
    {
        _haveGarden = true;
        return this;
    }

    public IHouseBuilder HavePool()
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

#region Example 2
class MailService
{
    public string From { get; set; } = default!;
    public string To { get; set; } = default!;
    public string Subject { get; set; } = default!;
    public string Body { get; set; } = default!;
    public List<string> Attachments { get; set; } = new();

    public MailService WithFrom(string value)
    {
        From = value;
        return this;
    }

    public MailService WithTo(string value)
    {
        To = value;
        return this;
    }

    public MailService WithSubject(string value)
    {
        Subject = value;
        return this;
    }

    public MailService WithBody(string value)
    {
        Body = value;
        return this;
    }

    public MailService WithAttachment(List<string> values)
    {
        Attachments = values;
        return this;
    }
    public void Send()
    {
        Console.WriteLine("From: {0}", From);
        Console.WriteLine("To: {0}", To);
        Console.WriteLine("Subject: {0}", Subject);
        Console.WriteLine("Body: {0}", Body);
        Console.WriteLine("Mail sended...");
    }
}
#endregion