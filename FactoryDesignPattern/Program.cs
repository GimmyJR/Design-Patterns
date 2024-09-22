using static FactoryDesignPattern.Program;

namespace FactoryDesignPattern
{
    internal class Program
    {
        //before
        //public class EmailNotification
        //{
        //    public void Send(string message)
        //    {
        //        Console.WriteLine($"Sending Email: {message}");
        //    }
        //}

        //public class SMSNotification
        //{
        //    public void Send(string message)
        //    {
        //        Console.WriteLine($"Sending SMS: {message}");
        //    }
        //}

        //public class PushNotification
        //{
        //    public void Send(string message)
        //    {
        //        Console.WriteLine($"Sending Push Notification: {message}");
        //    }
        //}

        //public class NotificationService
        //{
        //    public void Notify(string notificationType, string message)
        //    {
        //        if (notificationType == "Email")
        //        {
        //            var email = new EmailNotification();
        //            email.Send(message);
        //        }
        //        else if (notificationType == "SMS")
        //        {
        //            var sms = new SMSNotification();
        //            sms.Send(message);
        //        }
        //        else if (notificationType == "Push")
        //        {
        //            var push = new PushNotification();
        //            push.Send(message);
        //        }
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    NotificationService service = new NotificationService();
        //    service.Notify("Email", "Hello via Email!");
        //    service.Notify("SMS", "Hello via SMS!");
        //    service.Notify("Push", "Hello via Push Notification!");
        //}




        //after :
        public interface INotifaction
        {
            public void Send(string message);
        }

        public class EmailNotification : INotifaction
        {
            public void Send(string message)
            {
                Console.WriteLine($"Sending Email: {message}");
            }
        }

        public class SMSNotification : INotifaction
        {
            public void Send(string message)
            {
                Console.WriteLine($"Sending SMS: {message}");
            }
        }


        public class PushNotification : INotifaction
        {
            public void Send(string message)
            {
                Console.WriteLine($"Sending Push Notification: {message}");
            }
        }

        public static class NotificationFactory
        {
            public static INotifaction CreateNotifaction(string notificationType)
            {
                if (notificationType == "Email")
                {
                    return new EmailNotification();
                }
                else if (notificationType == "SMS")
                {
                    return new  SMSNotification();
                }
                else if (notificationType == "Push")
                {
                    return new PushNotification();
                }
                throw new ArgumentNullException();
            }
        }

        public class NotificationService
        {
            public void Notify(string notificationType, string message)
            {
                INotifaction notifaction = NotificationFactory.CreateNotifaction(notificationType);
                notifaction.Send(message);
            }
        }

        
        static void Main(string[] args)
        {
            NotificationService service = new NotificationService();

            service.Notify("Email", "Hello via Email!");
            service.Notify("SMS", "Hello via SMS!");
            service.Notify("Push", "Hello via Push Notification!");
        }
        

    }
}

