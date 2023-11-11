using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.Entities.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, int number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            
            AddNotifications(
                new Contract<Address>()
                .Requires()
                .IsGreaterOrEqualsThan(street, 3, "Address.Street", "O Nome da rua deve contem pelo menos 3 caracteres")
                .IsLowerOrEqualsThan(street, 255, "Address.Street", "O Nome da rua deve contem no máximo 255 caracteres")
                .IsGreaterThan(number, 0, "Address.Number", "O número deve ser maior que 0")
                .IsGreaterOrEqualsThan(neighborhood, 3, "Address.Neighborhood", "O Bairro deve contem pelo menos 3 caracteres")
                .IsLowerOrEqualsThan(neighborhood, 255, "Address.Neighborhood", "O Bairro deve contem no máximo 255 caracteres")
                .IsGreaterOrEqualsThan(city, 3, "Address.City", "A cidade deve contem pelo menos 3 caracteres")
                .IsLowerOrEqualsThan(city, 255, "Address.City", "A cidade deve contem no máximo 255 caracteres")
                .AreEquals(state, 2, "Address.State", "O estado deve conter 2 caracteres")
                .AreEquals(country, 2, "Address.Country", "O país deve conter 2 caracteres")
                .AreEquals(zipCode, 8, "Address.ZipCode", "O CEP deve conter 8 caracteres")
            );
        }

        public string Street { get; private set; }
        public int Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}