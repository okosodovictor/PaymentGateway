using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Application.Interfaces
{
    public interface IPaymentRepository
    {
         Task Create(Payment payment);
         Task<Payment> Update(Payment payment);
         Task<Payment> GetPaymentByPaymentReference(string paymentReference);
    }
}
