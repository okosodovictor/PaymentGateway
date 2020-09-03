using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Application.Repositories
{
    public interface IMerchantRepository
    {
        Task<Merchant> GetMerchantById(Guid merchantId);
    }
}
