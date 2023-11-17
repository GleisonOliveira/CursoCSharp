using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Mocks;

namespace PaymentContext.Domain.Commands;

[TestClass]
public class SubscriptionHandlerTests
{
    [TestMethod]
    public void ShouldReturnErrornWhenDocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBilletSubscriptionCommand();
        command.BarCode = "999999999999999";
        command.Name =  new Name("User", "Name");
        command.Document = new Document("99999999999");
        command.Email = new Email("user@test.com");
        command.BoletoNumber = "999999999999999";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddDays(1);
        command.Total = 60;
        command.TotalPaid = 60;
        command.Payer = "Name of payer";
        command.PayerDocument = new Document("99999999999");;
        command.PayerEmail = new Email("user@test.com");;
        command.PayerAddress = new Address("street", "200", "village", "city", "state", "br", "0000000");

        handler.Handle(command);

        Assert.AreEqual(false, handler.IsValid);
    }
}