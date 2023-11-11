using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.Enums;
using PaymentContext.Domain.Entities.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    private static readonly Name _name = new("Name", "Last");
    private static readonly Document _doc = new("280.611.800-06");
    private static readonly Email _email = new("email@valid.com");

    private static Address _address = new("Street", 200, "Neighborhood", "City", "SP", "BR", "00000000");

    private static readonly PayPalPayment _payment = new("123", DateTime.Now, DateTime.Now.AddHours(1), 10, 10, _address, _doc, "Payer", _email);

    private static readonly Subscription _subscription = new(DateTime.Now);

    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        var student = new Student(_name, _doc, _email);

        student.AddSubscription(new Subscription(DateTime.Now));

        Assert.IsFalse(student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenSubscriptionHasPayment()
    {
        var student = new Student(_name, _doc, _email);
        _subscription.AddPayment(_payment);

        student.AddSubscription(_subscription);

        Assert.IsTrue(student.IsValid);
    }

    
    [TestMethod]
    public void ShouldReturnErronWhenSubscriptionAlreadyHasPayment()
    {
        var student = new Student(_name, _doc, _email);
        _subscription.AddPayment(_payment);
        _subscription.AddPayment(_payment);

        student.AddSubscription(_subscription);
        
        Assert.IsTrue(student.IsValid);
    }
}