namespace OOP.NotificationContext
{
    /// <summary>
    /// Define a new notification to notifiables
    /// </summary>
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