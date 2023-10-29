namespace OOP.NotificationContext
{
    public class Notification : INotification
    {
        public string Property { get; }
        public string Message { get; }

        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}