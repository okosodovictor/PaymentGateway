using PaymentGateway.Application.Business;
using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Application.Interfaces.Bank
{
    public interface IBankClient
    {
        Task<BankResponse> ProcessPayment(BankRequest bankRequest);
    }
}
