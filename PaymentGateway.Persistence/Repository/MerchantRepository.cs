using Microsoft.EntityFrameworkCore;
using PaymentGateway.Application.Repositories;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Persistence.EFConfiguration;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Persistence.Repository
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly PaymentDbContext _context;
        
        public MerchantRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task<Merchant> GetMerchantById(Guid merchantId)
        {
            return await _context.Merchants.FindAsync(merchantId);
        }
    }
}
