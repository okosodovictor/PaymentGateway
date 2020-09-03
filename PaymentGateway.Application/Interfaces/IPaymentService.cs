using PaymentGateway.Application.Business;
using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Application
{
    public interface IPaymentService
    {
        Task<PaymentResponse> RequestPayment(PaymentRequest model);
        Task<Payment> GetPaymentByReference(string reference);
    }
}
