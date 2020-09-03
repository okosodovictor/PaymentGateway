using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Application.Business
{
    public class PaymentResponse
    {
        public string Reference { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
