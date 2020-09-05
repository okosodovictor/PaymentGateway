using PaymentGateway.Application.Business;
using PaymentGateway.Application.Interfaces.Bank;
using PaymentGateway.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PaymentGateway.Banks.BankAPIClients
{
    public class MockBank : IBankClient
    {
        private string GenerateReference()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
        }

        public async Task<BankResponse> ProcessPayment(BankRequest bankRequest)
        {
            var status = PaymentStatus.Success;
            var message = string.Empty;
            switch (bankRequest.CardNumber)
            {
                case "1234 1234 1234 1234":
                    status = PaymentStatus.Failure;
                    message = "Insufficient Funds";
                    break;
                    // ......
            }

            return await Task.FromResult(
                    new BankResponse
                    {
                        Reference = GenerateReference(),
                        Status = status,
                        Message = message
                    });
        }
    }
}
