using OOP.NotificationContext;

namespace OOP.SharedContext
{
    public abstract class Base : Notifiable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}