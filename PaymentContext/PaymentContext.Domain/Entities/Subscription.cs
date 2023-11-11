﻿using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Subscription : Entity
{
    public Subscription(DateTime? expireDate)
    {
        CreateDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        ExpireDate = expireDate;
        Active = false;
        _payments = new List<Payment>();
    }

    private IList<Payment> _payments;

    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool Active { get; private set; }
    public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

    public void AddPayment(Payment payment)
    {
        AddNotifications(new Contract<Subscription>()
            .Requires()
            .IsGreaterThan(
                DateTime.Now,
                payment.PaidDate,
                "Subscription.Payments",
                "A data do pagamento deve ser futura"
            )
        );

        if (!IsValid) return;

        _payments.Add(payment);
    }

    public void Activate()
    {
        Active = true;
        LastUpdateDate = DateTime.Now;
    }
    public void Deactivate()
    {
        Active = false;
        LastUpdateDate = DateTime.Now;
    }
}
