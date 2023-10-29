using OOP.NotificationContext;
using POO.ContentContext;

namespace OOP.ContentContext
{
    public abstract class ContentBase : Notifiable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}