using PaymentContext.Shared.Handlers;

namespace PaymentContext.Shared.Commands;

public interface ICommand
{
    void Validate();
}