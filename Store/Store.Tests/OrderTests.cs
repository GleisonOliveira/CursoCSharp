using Store.Domain.Entities;
using Store.Domain.Enums;

namespace store.tests;

[TestClass]
public class OrderTests
{
    private readonly Customer _customer = new Customer("Gleison", "email@email.com");

    private readonly Product _product = new Product("Produto", 10, true);

    [TestMethod]
    [TestCategory("Domain")]
    public void TestShouldGenerateNewIdWhenOrderIsCreated()
    {
        var order = new Order(_customer, 0, null);

        Assert.AreEqual(8, order.Number.Length);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void TestShouldGenerateWithPendindStatus()
    {
        var order = new Order(_customer, 0, null);

        Assert.AreEqual(EOrderStatus.WaitingPayment, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void TestShouldGenerateWithWaitingDeliveryStatusWhenHasAPayment()
    {
        var order = new Order(_customer, 0, null);
        order.AddItem(_product, 1);
        order.Pay(10);

        Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void TestShouldReturnCanceledStatusWhenOrderIsCanceled()
    {
        var order = new Order(_customer, 0, null);
        order.Cancel();

        Assert.AreEqual(EOrderStatus.Canceled, order.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void TestShouldReturnEmptyWhenItemQuantityIsInvalid()
    {
        var order = new Order(_customer, 0, null);
        order.AddItem(_product, -10);

        Assert.AreEqual(0, order.Items.Count);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void TestShouldReturnCorrectTotal()
    {
        var order = new Order(_customer, 10, null);
        order.AddItem(_product, 4);

        Assert.AreEqual(50, order.Total());
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void TestShouldReturnCorrectTotalWhenDiscountIsExpired()
    {
        var expiredDiscount = new Discount(10, DateTime.Today.AddDays(-1));
        var order = new Order(_customer, 10, expiredDiscount);
        order.AddItem(_product, 4);

        Assert.AreEqual(50, order.Total());
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void TestShouldReturnCorrectTotalWhenDiscountIsValid()
    {
        var validDiscount = new Discount(10, DateTime.Today.AddDays(5));
        var order = new Order(_customer, 10, validDiscount);
        order.AddItem(_product, 4);

        Assert.AreEqual(40, order.Total());
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void TestShouldReturnCorrectTotalHasDeliveryFee()
    {
        var order = new Order(_customer, 10, null);
        order.AddItem(_product, 4);

        Assert.AreEqual(40, order.Total());
    }
}