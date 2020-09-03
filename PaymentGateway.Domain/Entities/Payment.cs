using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string Cvv { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid MerchantId { get; set; }
        public virtual Merchant Merchant { get; set; }
    }
}
