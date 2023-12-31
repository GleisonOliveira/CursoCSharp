﻿using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Domain.Mocks;

public class FakeStudentRepository : IStudentRepository
{
    public void CreateSubscription(Student student)
    {

    }

    public bool DocumentExists(string document)
    {
        if (document == "99999999999")
            return true;

        return false;
    }

    public bool EmailExists(string email)
    {
        if (email == "email@test.com")
            return true;

        return false;
    }
}