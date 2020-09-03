using PaymentGateway.Application.Business;
using PaymentGateway.Application.Interfaces.Bank;
using PaymentGateway.Domain.Entities;
using System;

namespace PaymentGateway.Banks.BankAPIClients
{
    public class MockBank : IBankClient
    {
        public string GenerateReference()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
        }

        public BankResponse ProcessPayment(BankRequest bankRequest)
        {
            var status = PaymentStatus.Success;
            var message = string.Empty;
            switch(bankRequest.CardNumber) {
                case "1234 1234 1234 1234":
                    status = PaymentStatus.Failure;
                    message = "Insufficient Funds";
                    break;
                    // ......
            }

            return new BankResponse
            {
                Reference = GenerateReference(),
                Status = status,
                Message = message
            };
        }
    }
}
