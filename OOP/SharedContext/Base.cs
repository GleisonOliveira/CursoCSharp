using OOP.NotificationContext;

namespace OOP.SharedContext
{
    internal abstract class Base : Notifiable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}