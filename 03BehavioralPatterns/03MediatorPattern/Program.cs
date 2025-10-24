Console.WriteLine("Mediator Pattern...");

var chatRoom = new ChatRoomMeditor();
var user1 = new User() { Name = "Taner" };
var user2 = new User() { Name = "Ahmet" };
var user3 = new User() { Name = "Ayşe" };

chatRoom.Register(user1);
chatRoom.Register(user2);
chatRoom.Register(user3);

chatRoom.Send(user1.Name, user2.Name, "Hello!");

Console.ReadLine();

interface IChatMediator
{
    void Register(User user);
    void Send(string from, string to, string message);
}

class ChatRoomMeditor : IChatMediator
{
    private readonly List<User> users = new();
    public void Register(User user)
    {
        if (!users.Any(p => p.Name == user.Name))
        {
            users.Add(user);
        }
    }

    public void Send(string from, string to, string message)
    {
        var user = users.FirstOrDefault(p => p.Name == to);
        if (user is null)
        {
            throw new ArgumentNullException("user");
        }

        user.Recieve(from, message);

    }
}

class User
{
    public string Name { get; set; } = default!;
    public void Recieve(string name, string message)
    {
        Console.WriteLine("{0} recieved from {1}: {2}", Name, name, message);
    }
}