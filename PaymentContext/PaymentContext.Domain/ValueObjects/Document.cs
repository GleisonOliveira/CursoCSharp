using PaymentContext.Domain.Entities.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.Entities.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type = EDocumentType.CPF)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
    }
}