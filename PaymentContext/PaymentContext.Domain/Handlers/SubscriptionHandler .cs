using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Entities.Enums;
using PaymentContext.Domain.Entities.ValueObjects;
using PaymentContext.Domain.Repositories;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBilletSubscriptionCommand>, IHandler<CreatePayPalSubscriptionCommand>
{
    private readonly IStudentRepository _repository;
    private readonly IEmailService _emailService;

    public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    public ICommandResult Handle(CreateBilletSubscriptionCommand command)
    {
        if (_repository.DocumentExists(command.Document.Number.ToString()))
            AddNotification("Document", "Este CPF já está em uso");

        if (_repository.EmailExists(command.Email.Address))
            AddNotification("Email", "Este E-mail já está em uso");

        var student = new Student(command.Name, command.Document, command.Email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new BilletPayment(
            command.BarCode,
            command.BoletoNumber,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.PayerAddress,
            command.PayerDocument,
            command.Payer,
            command.PayerEmail
        );

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        AddNotifications(command.Name, command.Document, command.PayerDocument, command.Email, command.PayerEmail, command.PayerAddress, student, subscription, payment);

        if (command.Address != null)
        {
            AddNotifications(command.Address);
        }

        if (!IsValid)
            return new CommandResult(false, "The signature cant be created");


        _repository.CreateSubscription(student);

        _emailService.Send(student.Name.FirstName, student.Email.Address, "Welcome", "The signature was created");

        return new CommandResult(true, "Signature created with success");
    }

    public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
    {
        if (_repository.DocumentExists(command.Document.Number.ToString()))
            AddNotification("Document", "This document is already registered");

        if (_repository.EmailExists(command.Email.Address))
            AddNotification("Email", "This email is already registered");

        var student = new Student(command.Name, command.Document, command.Email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));

        var payment = new PayPalPayment(
            command.TransactionCode,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.PayerAddress,
            command.PayerDocument,
            command.Payer,
            command.PayerEmail
        );

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        AddNotifications(command.Name, command.Document, command.PayerDocument, command.Email, command.PayerEmail, command.Address, command.PayerAddress, student, subscription, payment);

        _repository.CreateSubscription(student);

        _emailService.Send(student.Name.FirstName, student.Email.Address, "Welcome", "The signature was created");

        return new CommandResult(true, "Signature created with success");
    }
}