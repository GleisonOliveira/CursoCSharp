using OOP.NotificationContext;

namespace POO.ContentContext
{
    /// <summary>
    /// Define the class as notifiable and able to be notifiable
    /// </summary>
    public interface INotifiable
    {
        /// <summary>
        /// List of notifications
        /// </summary>
        public List<INotification> Notifications { get; set; }

        /// <summary>
        /// Verify if object is valid
        /// </summary>
        public bool IsValid { get; }

        /// <summary>
        /// Add a new notification
        /// </summary>
        /// <param name="notification"></param>
        public void AddNotification(INotification notification);

        /// <summary>
        /// Add a notification range
        /// </summary>
        /// <param name="notifications"></param>
        public void AddNotifications(IEnumerable<INotification> notifications);
    }
}