using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Domain.Mocks;

public class FakeEmailService : IEmailService
{
    public void Send(string to, string email, string subject, string body)
    {
    }
}