Console.WriteLine("Singleton Pattern...");

Logger logger1 = Logger.Instance;
logger1.Log("Hello world1!");

Logger logger2 = Logger.Instance;
logger2.Log("Hello world2!");

Logger logger3 = Logger.Instance;
logger3.Log("Hello world3!");

Logger logger4 = Logger.Instance;
logger4.Log("Hello world4!");

Console.ReadLine();

#region Static Solution
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
    public static Logger Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new Logger();
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