using System.Text.RegularExpressions;
using Flunt.Validations;
using PaymentContext.Domain.Entities.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.Entities.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type = EDocumentType.CPF)
        {
            Number = Regex.Replace(number, @"\D", "");
            Type = type;

            AddNotifications(
                new Contract<Document>()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido")
            );
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool Validate()
        {
            if (Type == EDocumentType.CPF && Number.Length == 11)
            {
                return true;
            }

            if (Type == EDocumentType.CNPJ && Number.Length == 14)
            {
                return true;
            }

            return false;
        }
    }
}