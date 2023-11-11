using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.Entities.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(
                new Contract<Name>()
                .Requires()
                .IsGreaterOrEqualsThan(firstName, 3, "Name.FirstName", "O Nome deve contem pelo menos 3 caracteres")
                .IsGreaterOrEqualsThan(lastName, 3, "Name.LastName", "O Sobrenome deve contem pelo menos 3 caracteres")
                .IsLowerOrEqualsThan(lastName, 40, "Name.LastName", "O Sobrenome deve contem pelo menos 40 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}