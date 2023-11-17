using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateBilletSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public Name Name { get; set; } = null!;
    public Document Document { get; set; } = null!;
    public Email Email { get; set; } = null!;
    public Address? Address { get; set; } = null;
    public string BarCode { get; set; } = null!;
    public string BoletoNumber { get; set; } = null!;
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; } = null!;
    public Document PayerDocument { get; set; } = null!;
    public Email PayerEmail { get; set; } = null!;

    public Address PayerAddress { get; set; } = null!;

    public void Validate()
    {
        AddNotifications(new Contract<CreateBilletSubscriptionCommand>().IsGreaterOrEqualsThan(BarCode, 10, "BarCode"));
    }
}