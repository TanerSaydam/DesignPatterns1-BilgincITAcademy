using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Singleton Pattern...");

//Logger logger1 = Logger.Instance;
//logger1.Log("Hello world1!");

//Logger logger2 = Logger.Instance;
//logger2.Log("Hello world2!");

//Logger logger3 = Logger.Instance;
//logger3.Log("Hello world3!");

//Logger logger4 = Logger.Instance;
//logger4.Log("Hello world4!");

ServiceCollection services = new(); //DI Container
services.AddSingleton<DILogger>();

using var serviceProvider = services.BuildServiceProvider();
DILogger diLogger1 = serviceProvider.GetRequiredService<DILogger>();
diLogger1.Log("Hello world1!");

DILogger diLogger2 = serviceProvider.GetRequiredService<DILogger>();
diLogger2.Log("Hello world2!");

DILogger diLogger3 = serviceProvider.GetRequiredService<DILogger>();
diLogger3.Log("Hello world3!");

//DILogger diLog = new();

Console.ReadLine();

#region Static çözüm
static class StaticLogger
{
    public static void Log(string message)
    {
        Console.WriteLine(message);
    }
}
#endregion

#region 1994 deki teorinin pratik çözümü
class Logger
{
    private static Logger? _instance;
    private static readonly object _lock = new object();
    public static Logger Instance
    {
        get
        {
            lock (_lock) //threat safe
            {
                if (_instance is null)
                {
                    _instance = new Logger();
                }
            }
            return _instance;
        }
    }
    private Logger()
    {

    }
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
#endregion

#region Dependency Injection çözümü
class DILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
#endregion