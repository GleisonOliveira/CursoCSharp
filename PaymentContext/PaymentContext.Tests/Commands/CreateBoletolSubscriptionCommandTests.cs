using PaymentContext.Domain.Entities.ValueObjects;

namespace PaymentContext.Domain.Commands;

[TestClass]
public class CreateBilletSubscriptionCommandTests
{
    [TestMethod]
    public void ShouldReturnErrornWhenBarcodeIsInvalid()
    {
        var command = new CreateBilletSubscriptionCommand();
        command.BarCode = "12345";

        command.Validate();
        Assert.AreEqual(false, command.IsValid);
    }
}