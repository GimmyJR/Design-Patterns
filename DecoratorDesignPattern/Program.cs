using static DecoratorDesignPattern.Program;

namespace DecoratorDesignPattern
{
    internal class Program
    {
        //before
        //public class EmailNotification
        //{
        //    public virtual void Send(string message)
        //    {
        //        Console.WriteLine($"Sending Email: {message}");
        //    }
        //}

        
        //public class EmailAndSmsNotification : EmailNotification
        //{
        //    public override void Send(string message)
        //    {
        //        base.Send(message); 
        //        SendSms(message);   
        //    }

        //    private void SendSms(string message)
        //    {
        //        Console.WriteLine($"Sending SMS: {message}");
        //    }
        //}

        //public class EmailAndSlackNotification : EmailNotification
        //{
        //    public override void Send(string message)
        //    {
        //        base.Send(message); 
        //        SendSlack(message); 
        //    }

        //    private void SendSlack(string message)
        //    {
        //        Console.WriteLine($"Sending Slack: {message}");
        //    }
        //}

        
        //public class EmailSmsAndSlackNotification : EmailAndSmsNotification
        //{
        //    public override void Send(string message)
        //    {
        //        base.Send(message); 
        //        SendSlack(message); 
        //    }

        //    private void SendSlack(string message)
        //    {
        //        Console.WriteLine($"Sending Slack: {message}");
        //    }
        //}

       
        //public static void Main(string[] args)
        //{
            
        //    EmailNotification notification = new EmailAndSmsNotification();
        //    notification.Send("Hello!");

            
        //    notification = new EmailSmsAndSlackNotification();
        //    notification.Send("Hello again!");
        //}


        //after
        public interface Inotification
        {
            void send(string message);
        }
        public class EmailNotification : Inotification
        {
            public void send(string message)
            {
                Console.WriteLine($"Sending Email: {message}");
            }
        }


        public class NotificationDecorator : Inotification
        {
            protected Inotification notification;

            public NotificationDecorator(Inotification _notification)
            {
                notification = _notification;
            }
            public virtual void send(string message)
            {
                notification.send(message);
            }
        }

        public class SmsNotificationDecorator : NotificationDecorator
        {
            public SmsNotificationDecorator(Inotification _notification) : base(_notification)
            {
            }

            public override void send(string message)
            {
                base.send(message);
                SendSms(message);
            }
            private void SendSms(string message)
            {
                Console.WriteLine($"Sending SMS: {message}");
            }
        }
        public class SlackNotificationDecorator : NotificationDecorator
        {
            public SlackNotificationDecorator(Inotification _notification) : base(_notification)
            {
            }

            public override void send(string message)
            {
                base.send(message);
                SendSlack(message);
            }
            private void SendSlack(string message)
            {
                Console.WriteLine($"Sending Slack: {message}");
            }
        }

        public static void Main(string[] args)
        {
            Inotification emailNotification = new EmailNotification();
            emailNotification.send("Hello!");

            Inotification emailSms = new SmsNotificationDecorator(emailNotification);
            emailSms.send("Hello With SMS!");

            Inotification emailSlack = new SlackNotificationDecorator(emailNotification);
            emailSlack.send("Hello With Slack!");
            
        }

    }
}
