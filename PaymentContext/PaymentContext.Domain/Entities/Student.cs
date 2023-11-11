using Flunt.Validations;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    public Student(Name name, Document document, Email email)
    {
        Name = name;
        Document = document;
        Email = email;
        _subscriptions = new List<Subscription>();

        AddNotifications(name, document, email);
    }

    private IList<Subscription> _subscriptions;
    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address? Address { get; private set; }
    public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

    public void AddSubscription(Subscription subscription)
    {
        var hasSubscriptionActive = false;

        foreach (var sub in _subscriptions)
        {
            if (sub.Active)
            {
                hasSubscriptionActive = true;
            }
        }

        AddNotifications(new Contract<Student>()
            .Requires()
            .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já tem uma assinatura ativa")
            .IsGreaterThan(subscription.Payments.Count, 0, "Student.Subscription.Payments", "Essa assinatura não possui pagamento")
        );

        _subscriptions.Add(subscription);
    }
}
