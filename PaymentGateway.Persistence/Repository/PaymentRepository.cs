using Microsoft.EntityFrameworkCore;
using PaymentGateway.Application.Interfaces;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Persistence.EFConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Persistence.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _dbContext;
        public PaymentRepository(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Payment payment)
        {
            if (payment != null)
            {
                _dbContext.Payments.Add(payment);
               await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Payment> GetPaymentByPaymentReference(string reference)
        {
            return await _dbContext.Payments.FirstOrDefaultAsync(r=>r.Reference==reference);
        }

        public async Task<Payment> Update(Payment payment)
        {
            _dbContext.Payments.Update(payment);
            await _dbContext.SaveChangesAsync();
            return payment;
        }
    }
}
