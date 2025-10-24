Console.WriteLine("Chain of Responsibility Pattern...");

var low = new Level1Support();
var mid = new Level2Support();
var hig = new ManagerSupport();

low.SetNext(mid).SetNext(hig);

low.HandleRequest(new SupportRequest("Password reset", 1));
low.HandleRequest(new SupportRequest("Email not response", 2));
low.HandleRequest(new SupportRequest("System doesn't work", 3));

Console.ReadLine();

class SupportRequest
{
    public string Name { get; set; }
    public int Level { get; set; }

    public SupportRequest(string name, int level)
    {
        Name = name;
        Level = level;
    }
}

abstract class SupportHandler
{
    public SupportHandler _next;
    public SupportHandler SetNext(SupportHandler next)
    {
        _next = next;
        return next;
    }

    public abstract void HandleRequest(SupportRequest request);
}

class Level1Support : SupportHandler
{
    public override void HandleRequest(SupportRequest request)
    {
        if (request.Level == 1)
        {
            Console.WriteLine("[Level 1] Resolved: {0}", request.Name);
        }
        else
        {
            //şu şartkı kontrol et eğer şart ok ise sonraya devret yoksa hata fırlat
            if (true)
            {
                _next?.HandleRequest(request);
            }
            else
            {
                throw new ArgumentException("");
            }

        }
    }
}

class Level2Support : SupportHandler
{
    public override void HandleRequest(SupportRequest request)
    {
        if (request.Level == 2)
        {
            Console.WriteLine("[Level 2] Resolved: {0}", request.Name);
        }
        else
        {
            _next?.HandleRequest(request);
        }
    }
}

class ManagerSupport : SupportHandler
{
    public override void HandleRequest(SupportRequest request)
    {
        if (request.Level == 3)
        {
            Console.WriteLine("[Manager] Resolved: {0}", request.Name);
        }
        else
        {
            _next?.HandleRequest(request);
        }
    }
}