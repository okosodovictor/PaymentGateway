using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.API.Models
{
    public class PaymentDto
    {
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string Status { get; set; }
        public string ExpiringDate { get; set; }
    }
}
