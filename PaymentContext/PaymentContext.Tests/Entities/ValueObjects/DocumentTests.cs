using PaymentContext.Domain.Entities.Enums;
using PaymentContext.Domain.Entities.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("222559", EDocumentType.CNPJ);

        Assert.IsFalse(doc.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("98.511.478/0001-80")]
    [DataRow("61294970000131")]
    [DataRow("98--511--478/0001-80")]
    public void ShouldReturnSuccessWhenCNPJIsValid(string cnpj)
    {
        var doc = new Document(cnpj, EDocumentType.CNPJ);

        Assert.IsTrue(doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("222559");

        Assert.IsFalse(doc.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("02226352074")]
    [DataRow("585.585.730-18")]
    [DataRow("585585730-18")]
    public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
    {
        var doc = new Document(cpf);

        Assert.IsTrue(doc.IsValid);
    }
}