using Flunt.Notifications;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateCreditCardSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public Name Name { get; set; } = null!;
    public Document Document { get; set; } = null!;
    public Email Email { get; set; } = null!;
    public Address? Address { get; set; } = null;
    public string TransactionCode { get; set; } = null!;
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; } = null!;
    public Document PayerDocument { get; set; } = null!;
    public Email PayerEmail { get; set; } = null!;
    public Address PayerAddress { get; set; } = null!;
    public string CardHolderName { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
    public string LastTransactionNumber { get; set; } = null!;
    public string PaymentNumber { get; set; } = null!;

    public void Validate()
    {
        throw new NotImplementedException();
    }
}