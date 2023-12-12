using Flunt.Notifications;

namespace Store.Domain.Entities;

public abstract class BaseEntity : Notifiable<Notification>
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; private set; }
}
