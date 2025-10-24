Console.WriteLine("Bridge Pattern...");

var consoleProvider = new ConsoleLogProvider();
var fileProvider = new FileLogProvider();

LogBase applog = new AppLog(consoleProvider);
applog.Write("Hello world from app");

LogBase auditlog = new AuditLog(fileProvider);
auditlog.Write("Hello world from audit");

Console.ReadLine();

#region Implementation
interface ILogProvider
{
    void Log(string message);
}

class ConsoleLogProvider : ILogProvider
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class FileLogProvider : ILogProvider
{
    public void Log(string message)
    {
        //File.AppendText(message);
        Console.WriteLine("File saved...");
    }
}
#endregion

#region Abstraction
abstract class LogBase //primary constructor
{
    public readonly ILogProvider _logProvider;

    protected LogBase(ILogProvider logProvider)
    {
        _logProvider = logProvider;
    }

    public abstract void Write(string message);
}

class AppLog : LogBase
{
    public AppLog(ILogProvider logProvider) : base(logProvider)
    {
    }

    public override void Write(string message)
    {
        _logProvider.Log(message);
    }
}

class AuditLog : LogBase
{
    public AuditLog(ILogProvider logProvider) : base(logProvider)
    {
    }

    public override void Write(string message)
    {
        _logProvider.Log(message);
    }
}
#endregion
