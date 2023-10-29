namespace OOP.NotificationContext
{
    /// <summary>
    /// Define an objet as a notifiable
    /// </summary>
    public abstract class Notifiable : INotifiable
    {
        public List<INotification> Notifications { get; set; } = new List<INotification>();

        public bool IsValid => Notifications.Any();

        public void AddNotification(INotification notification)
        {
            Notifications.Add(notification);
        }

        public void AddNotifications(IEnumerable<INotification> notifications)
        {
            Notifications.AddRange(notifications);
        }
    }
}