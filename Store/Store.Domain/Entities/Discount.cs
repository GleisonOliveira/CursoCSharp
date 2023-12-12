namespace Store.Domain.Entities;

public class Discount : BaseEntity
{
    public Discount(decimal amount, DateTime expireDate)
    {
        Amount = amount;
        ExpireDate = expireDate;
    }

    public decimal Amount { get; private set; }
    public DateTime ExpireDate { get; private set; }

    public bool IsDiscountValid()
    {
        return DateTime.Compare(DateTime.Now, ExpireDate) < 0;
    }

    public decimal Value()
    {
        if (IsDiscountValid())
            return Amount;

        return 0;
    }
}
