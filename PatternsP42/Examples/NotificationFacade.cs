using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Examples;


public class NotificationFacade
{
    private readonly SmsService _smsService = new SmsService();
    private readonly EmailService _emailService = new EmailService();
    private readonly PushService _pushService = new PushService();

    public void SendSimpleMessage(string text) {
        // реалізація відправки простого повідомлення через sms + push

        _smsService.SendSms("+1234567890", text);
        _pushService.SendPush("deviceToken", "Simple Message", text);

    }


    //    notificationFacade.SendSimpleMessage("Hello, this is a simple message.");
    //// смс + пуш
    //notificationFacade.SendWithTitle("Title!", "text");
    //// пуш + емейл
    //notificationFacade.SendUrgentPushWithSms("Urgent!", "This is an urgent message.");

}


public class SmsService
{
    public void SendSms(string phone, string text) { 

    }
    public bool CheckDelivery(string messageId) { 
    
        return true;
    }
}

public class EmailService
{
    public void SendEmail(string email, string subject, string body) { 
    }
    public void AddAttachment(string messageId, byte[] file) { 
    }
}

public class PushService
{
    public void SendPush(string deviceToken, string title, string body) { 
    }
    public void SetBadge(string deviceToken, int count) { 
    }
}