using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Behavioral;


public class MediatorClientCode
{
    // user1 -> user2, user3

    public void Run()
    {
        var user1 = new ChatUser { Email = "user1" };
        var user2 = new ChatUser { Email = "user2" };
        var user3 = new ChatUser { Email = "user3" };

        var chatMediator = new ChatMediator();
        chatMediator.RegisterUser(user1);
        chatMediator.RegisterUser(user2);
        chatMediator.RegisterUser(user3);


        user1.SendMessage(chatMediator, "Hello, everyone!");
        user2.SendMessage(chatMediator, "Hi, user1!");

      


    }
}   


public class ChatUser
{
    public string Email { get; set; }
    public List<string> ReceivedMessages { get; } = new List<string>();


    public void SendMessage(ChatMediator mediator, string message)
    {
        mediator.SendMessage(this, message);
    }



}


public class ChatMediator
{
    private List<ChatUser> _users = new List<ChatUser>();
    public void RegisterUser(ChatUser user)
    {
        _users.Add(user);
    }
    public void SendMessage(ChatUser sender, string message)
    {
        foreach (var user in _users)
        {
            if (user.Email != sender.Email)
            {
                user.ReceivedMessages.Add($"Message from {sender.Email}: {message}");
            }
        }
    }
}



