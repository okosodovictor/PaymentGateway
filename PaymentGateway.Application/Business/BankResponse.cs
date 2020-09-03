using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Application.Business
{
    public class BankResponse
    {
        public string Reference { get; set; }
        public PaymentStatus Status { get; set; }
        public string Message { get; set; }
    }
}
