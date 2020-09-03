using PaymentGateway.Application.Business;
using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Application.Interfaces.Bank
{
    public interface IBankClient
    {
        BankResponse ProcessPayment(BankRequest bankRequest);
    }
}
