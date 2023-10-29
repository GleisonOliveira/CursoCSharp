namespace OOP.NotificationContext
{
    /// <summary>
    /// Define a class as notification
    /// </summary>
    public interface INotification
    {
        /// <summary>
        /// Notified property
        /// </summary>
        string Property { get; }

        /// <summary>
        /// Message of notification
        /// </summary>
        string Message { get; }
    }
}