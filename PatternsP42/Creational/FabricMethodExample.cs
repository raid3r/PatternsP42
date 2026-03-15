using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Creational;




public interface IMessageSender
{
    void Send(string message);
}

public class EmailSender : IMessageSender
{
    private string _smtpServer;
    private int _port;
    public EmailSender(string smtpServer, int port)
    {
        _port = port;
        _smtpServer = smtpServer;
    }

    public void Send(string message)
    {
        Console.WriteLine($"Sending email with message: {message}");
    }
}

public class SmsSender : IMessageSender
{
    private string _key;
    private string _phone;
    public SmsSender(string key, string phone)
    {
        _key = key;
        _phone = phone;
    }

    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS with message: {message}");
    }
}

public class TelegramSender : IMessageSender
{
    private string _token;
    private string _chatId;
    public TelegramSender(string token, string chatId)
    {
        _token = token;
        _chatId = chatId;
    }
    public void Send(string message)
    {
        Console.WriteLine($"Sending Telegram message: {message}");
    }
}



public abstract class SenderCreator
{
    public abstract IMessageSender CreateSender();
}

public class TelegramSenderCreator : SenderCreator
{
    private string _token;
    private string _chatId;
    public TelegramSenderCreator(string token, string chatId)
    {
        _token = token;
        _chatId = chatId;
    }
    public override IMessageSender CreateSender()
    {
        return new TelegramSender(_token, _chatId);
    }
}

public class EmailSenderCreator : SenderCreator
{
    private string _smtpServer;
    private int _port;
    public EmailSenderCreator(string smtpServer, int port)
    {
        _port = port;
        _smtpServer = smtpServer;
    }
    public override IMessageSender CreateSender()
    {
        return new EmailSender(_smtpServer, _port);
    }
}

public class SmsSenderCreator : SenderCreator
{
    private string _key;
    private string _phone;
    public SmsSenderCreator(string key, string phone)
    {
        _key = key;
        _phone = phone;
    }
    public override IMessageSender CreateSender()
    {
        return new SmsSender(_key, _phone);
    }
}




